using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class EventScheduleData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<EventScheduleData> _collection = null;
		private static IMongoCollection<EventScheduleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<EventScheduleData>("event_schedules"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static EventScheduleData DbCreateNew()
		{
			var result = new EventScheduleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<EventScheduleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"EventScheduleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			EventScheduleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"EventScheduleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<EventScheduleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<EventScheduleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<EventScheduleData>.Filter;
				var model = new ReplaceOneModel<EventScheduleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"EventScheduleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EventScheduleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EventScheduleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static EventScheduleData Null => NullObjectContainer.Get<EventScheduleData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, EventScheduleData> dataTable {
			get {
				DataTable<long, EventScheduleData> result;
				if (GameDb.TableExists<long, EventScheduleData>()) {
					result = GameDb.From<long, EventScheduleData>();
				} else {
					result = GameDb.CreateTable<long, EventScheduleData>();
					SetupEventScheduleDataTableIndexGenerated(result);
					SetupEventScheduleDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<EventScheduleData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<EventScheduleData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupEventScheduleDataTableIndex(DataTable<long, EventScheduleData> targetDataTable);

		private static void SetupEventScheduleDataTableIndexGenerated(DataTable<long, EventScheduleData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("QuestId", aData => (object)aData.questId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static EventScheduleData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (QuestId)
		public static List<EventScheduleData> GetDataListByQuestId(
			long questId)
		{
			return dataTable.GetDataList("QuestId", (object)questId);
		}
		#endregion
	}
}
