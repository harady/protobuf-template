using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class QuestGroupData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<QuestGroupData> _collection = null;
		private static IMongoCollection<QuestGroupData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<QuestGroupData>("quest_groups"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static QuestGroupData DbCreateNew()
		{
			var result = new QuestGroupData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<QuestGroupData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"QuestGroupData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			QuestGroupData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"QuestGroupData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<QuestGroupData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<QuestGroupData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<QuestGroupData>.Filter;
				var model = new ReplaceOneModel<QuestGroupData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"QuestGroupData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"QuestGroupData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"QuestGroupData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static QuestGroupData Null => NullObjectContainer.Get<QuestGroupData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, QuestGroupData> dataTable {
			get {
				DataTable<long, QuestGroupData> result;
				if (GameDb.TableExists<long, QuestGroupData>()) {
					result = GameDb.From<long, QuestGroupData>();
				} else {
					result = GameDb.CreateTable<long, QuestGroupData>();
					SetupQuestGroupDataTableIndexGenerated(result);
					SetupQuestGroupDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<QuestGroupData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<QuestGroupData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupQuestGroupDataTableIndex(DataTable<long, QuestGroupData> targetDataTable);

		private static void SetupQuestGroupDataTableIndexGenerated(DataTable<long, QuestGroupData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static QuestGroupData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<QuestGroupData> GetDataListByType(
			QuestGroupType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
	}
}
