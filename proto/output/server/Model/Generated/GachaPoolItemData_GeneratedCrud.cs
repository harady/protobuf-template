using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class GachaPoolItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<GachaPoolItemData> _collection = null;
		private static IMongoCollection<GachaPoolItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<GachaPoolItemData>("gacha_pool_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static GachaPoolItemData DbCreateNew()
		{
			var result = new GachaPoolItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<GachaPoolItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"GachaPoolItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			GachaPoolItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"GachaPoolItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<GachaPoolItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<GachaPoolItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<GachaPoolItemData>.Filter;
				var model = new ReplaceOneModel<GachaPoolItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"GachaPoolItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			return result;
		}
		#endregion
		#region MongoDb
		public static async Task<bool> DbDeleteDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var deleteResult = await collection
				.DeleteOneAsync(
					sessionHandle,
					aData => aData.id == id);
			Console.WriteLine($"GachaPoolItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}

		public static async Task<bool> DbDeleteDataByIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var keySet = ids.ToHashSet();
			var deleteResult = await collection
				.DeleteManyAsync(
					sessionHandle,
					aData => keySet.Contains(aData.id));
			Console.WriteLine($"GachaPoolItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static GachaPoolItemData Null => NullObjectContainer.Get<GachaPoolItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, GachaPoolItemData> dataTable {
			get {
				DataTable<long, GachaPoolItemData> result;
				if (GameDb.TableExists<long, GachaPoolItemData>()) {
					result = GameDb.From<long, GachaPoolItemData>();
				} else {
					result = GameDb.CreateTable<long, GachaPoolItemData>();
					SetupGachaPoolItemDataTableIndexGenerated(result);
					SetupGachaPoolItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<GachaPoolItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<GachaPoolItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupGachaPoolItemDataTableIndex(DataTable<long, GachaPoolItemData> targetDataTable);

		private static void SetupGachaPoolItemDataTableIndexGenerated(DataTable<long, GachaPoolItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("GachaPoolId", aData => (object)aData.gachaPoolId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static GachaPoolItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (GachaPoolId)
		public static List<GachaPoolItemData> GetDataListByGachaPoolId(
			long gachaPoolId)
		{
			return dataTable.GetDataList("GachaPoolId", (object)gachaPoolId);
		}
		#endregion
	}
}
