using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class DailyEventTableItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<DailyEventTableItemData> _collection = null;
		private static IMongoCollection<DailyEventTableItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<DailyEventTableItemData>("daily_event_table_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static DailyEventTableItemData DbCreateNew()
		{
			var result = new DailyEventTableItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<DailyEventTableItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"DailyEventTableItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			DailyEventTableItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"DailyEventTableItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<DailyEventTableItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<DailyEventTableItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<DailyEventTableItemData>.Filter;
				var model = new ReplaceOneModel<DailyEventTableItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"DailyEventTableItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"DailyEventTableItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"DailyEventTableItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static DailyEventTableItemData Null => NullObjectContainer.Get<DailyEventTableItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, DailyEventTableItemData> dataTable {
			get {
				DataTable<long, DailyEventTableItemData> result;
				if (GameDb.TableExists<long, DailyEventTableItemData>()) {
					result = GameDb.From<long, DailyEventTableItemData>();
				} else {
					result = GameDb.CreateTable<long, DailyEventTableItemData>();
					SetupDailyEventTableItemDataTableIndexGenerated(result);
					SetupDailyEventTableItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<DailyEventTableItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<DailyEventTableItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupDailyEventTableItemDataTableIndex(DataTable<long, DailyEventTableItemData> targetDataTable);

		private static void SetupDailyEventTableItemDataTableIndexGenerated(DataTable<long, DailyEventTableItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("DailyEventTableId", aData => (object)aData.dailyEventTableId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static DailyEventTableItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (DailyEventTableId)
		public static List<DailyEventTableItemData> GetDataListByDailyEventTableId(
			long dailyEventTableId)
		{
			return dataTable.GetDataList("DailyEventTableId", (object)dailyEventTableId);
		}
		#endregion
	}
}
