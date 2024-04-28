using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class DailyEventTableData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<DailyEventTableData> _collection = null;
		private static IMongoCollection<DailyEventTableData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<DailyEventTableData>("daily_event_tables"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static DailyEventTableData DbCreateNew()
		{
			var result = new DailyEventTableData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<DailyEventTableData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"DailyEventTableData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			DailyEventTableData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"DailyEventTableData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<DailyEventTableData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<DailyEventTableData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<DailyEventTableData>.Filter;
				var model = new ReplaceOneModel<DailyEventTableData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"DailyEventTableData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"DailyEventTableData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"DailyEventTableData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static DailyEventTableData Null => NullObjectContainer.Get<DailyEventTableData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, DailyEventTableData> dataTable {
			get {
				DataTable<long, DailyEventTableData> result;
				if (GameDb.TableExists<long, DailyEventTableData>()) {
					result = GameDb.From<long, DailyEventTableData>();
				} else {
					result = GameDb.CreateTable<long, DailyEventTableData>();
					SetupDailyEventTableDataTableIndexGenerated(result);
					SetupDailyEventTableDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<DailyEventTableData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<DailyEventTableData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupDailyEventTableDataTableIndex(DataTable<long, DailyEventTableData> targetDataTable);

		private static void SetupDailyEventTableDataTableIndexGenerated(DataTable<long, DailyEventTableData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static DailyEventTableData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
	}
}
