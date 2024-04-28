using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class EventQuestCategoryData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<EventQuestCategoryData> _collection = null;
		private static IMongoCollection<EventQuestCategoryData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<EventQuestCategoryData>("event_quest_categorys"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static EventQuestCategoryData DbCreateNew()
		{
			var result = new EventQuestCategoryData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<EventQuestCategoryData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"EventQuestCategoryData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			EventQuestCategoryData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"EventQuestCategoryData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<EventQuestCategoryData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<EventQuestCategoryData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<EventQuestCategoryData>.Filter;
				var model = new ReplaceOneModel<EventQuestCategoryData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"EventQuestCategoryData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EventQuestCategoryData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EventQuestCategoryData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static EventQuestCategoryData Null => NullObjectContainer.Get<EventQuestCategoryData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, EventQuestCategoryData> dataTable {
			get {
				DataTable<long, EventQuestCategoryData> result;
				if (GameDb.TableExists<long, EventQuestCategoryData>()) {
					result = GameDb.From<long, EventQuestCategoryData>();
				} else {
					result = GameDb.CreateTable<long, EventQuestCategoryData>();
					SetupEventQuestCategoryDataTableIndexGenerated(result);
					SetupEventQuestCategoryDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<EventQuestCategoryData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<EventQuestCategoryData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupEventQuestCategoryDataTableIndex(DataTable<long, EventQuestCategoryData> targetDataTable);

		private static void SetupEventQuestCategoryDataTableIndexGenerated(DataTable<long, EventQuestCategoryData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static EventQuestCategoryData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
	}
}
