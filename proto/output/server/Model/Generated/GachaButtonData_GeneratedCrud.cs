using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class GachaButtonData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<GachaButtonData> _collection = null;
		private static IMongoCollection<GachaButtonData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<GachaButtonData>("gacha_buttons"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static GachaButtonData DbCreateNew()
		{
			var result = new GachaButtonData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<GachaButtonData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"GachaButtonData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			GachaButtonData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"GachaButtonData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<GachaButtonData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<GachaButtonData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<GachaButtonData>.Filter;
				var model = new ReplaceOneModel<GachaButtonData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"GachaButtonData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"GachaButtonData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"GachaButtonData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static GachaButtonData Null => NullObjectContainer.Get<GachaButtonData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, GachaButtonData> dataTable {
			get {
				DataTable<long, GachaButtonData> result;
				if (GameDb.TableExists<long, GachaButtonData>()) {
					result = GameDb.From<long, GachaButtonData>();
				} else {
					result = GameDb.CreateTable<long, GachaButtonData>();
					SetupGachaButtonDataTableIndexGenerated(result);
					SetupGachaButtonDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<GachaButtonData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<GachaButtonData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupGachaButtonDataTableIndex(DataTable<long, GachaButtonData> targetDataTable);

		private static void SetupGachaButtonDataTableIndexGenerated(DataTable<long, GachaButtonData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("GachaId", aData => (object)aData.gachaId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static GachaButtonData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (GachaId)
		public static List<GachaButtonData> GetDataListByGachaId(
			long gachaId)
		{
			return dataTable.GetDataList("GachaId", (object)gachaId);
		}
		#endregion
	}
}
