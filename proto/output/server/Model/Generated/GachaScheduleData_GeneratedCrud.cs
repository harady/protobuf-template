using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class GachaScheduleData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<GachaScheduleData> _collection = null;
		private static IMongoCollection<GachaScheduleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<GachaScheduleData>("gacha_schedules"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static GachaScheduleData DbCreateNew()
		{
			var result = new GachaScheduleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<GachaScheduleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"GachaScheduleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			GachaScheduleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"GachaScheduleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<GachaScheduleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<GachaScheduleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<GachaScheduleData>.Filter;
				var model = new ReplaceOneModel<GachaScheduleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"GachaScheduleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"GachaScheduleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"GachaScheduleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static GachaScheduleData Null => NullObjectContainer.Get<GachaScheduleData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, GachaScheduleData> dataTable {
			get {
				DataTable<long, GachaScheduleData> result;
				if (GameDb.TableExists<long, GachaScheduleData>()) {
					result = GameDb.From<long, GachaScheduleData>();
				} else {
					result = GameDb.CreateTable<long, GachaScheduleData>();
					SetupGachaScheduleDataTableIndexGenerated(result);
					SetupGachaScheduleDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<GachaScheduleData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<GachaScheduleData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupGachaScheduleDataTableIndex(DataTable<long, GachaScheduleData> targetDataTable);

		private static void SetupGachaScheduleDataTableIndexGenerated(DataTable<long, GachaScheduleData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("GachaId", aData => (object)aData.gachaId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static GachaScheduleData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (GachaId)
		public static List<GachaScheduleData> GetDataListByGachaId(
			long gachaId)
		{
			return dataTable.GetDataList("GachaId", (object)gachaId);
		}
		#endregion
	}
}
