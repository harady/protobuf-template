using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class QuestData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<QuestData> _collection = null;
		private static IMongoCollection<QuestData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<QuestData>("quests"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static QuestData DbCreateNew()
		{
			var result = new QuestData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<QuestData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"QuestData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			QuestData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"QuestData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<QuestData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<QuestData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<QuestData>.Filter;
				var model = new ReplaceOneModel<QuestData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"QuestData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"QuestData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"QuestData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static QuestData Null => NullObjectContainer.Get<QuestData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, QuestData> dataTable {
			get {
				DataTable<long, QuestData> result;
				if (GameDb.TableExists<long, QuestData>()) {
					result = GameDb.From<long, QuestData>();
				} else {
					result = GameDb.CreateTable<long, QuestData>();
					SetupQuestDataTableIndexGenerated(result);
					SetupQuestDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<QuestData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<QuestData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupQuestDataTableIndex(DataTable<long, QuestData> targetDataTable);

		private static void SetupQuestDataTableIndexGenerated(DataTable<long, QuestData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("QuestGroupId", aData => (object)aData.questGroupId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static QuestData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (QuestGroupId)
		public static List<QuestData> GetDataListByQuestGroupId(
			long questGroupId)
		{
			return dataTable.GetDataList("QuestGroupId", (object)questGroupId);
		}
		#endregion
	}
}
