using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class RoundData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<RoundData> _collection = null;
		private static IMongoCollection<RoundData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<RoundData>("rounds"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static RoundData DbCreateNew()
		{
			var result = new RoundData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<RoundData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"RoundData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			RoundData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"RoundData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<RoundData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<RoundData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<RoundData>.Filter;
				var model = new ReplaceOneModel<RoundData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"RoundData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"RoundData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"RoundData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static RoundData Null => NullObjectContainer.Get<RoundData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, RoundData> dataTable {
			get {
				DataTable<long, RoundData> result;
				if (GameDb.TableExists<long, RoundData>()) {
					result = GameDb.From<long, RoundData>();
				} else {
					result = GameDb.CreateTable<long, RoundData>();
					SetupRoundDataTableIndexGenerated(result);
					SetupRoundDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<RoundData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<RoundData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupRoundDataTableIndex(DataTable<long, RoundData> targetDataTable);

		private static void SetupRoundDataTableIndexGenerated(DataTable<long, RoundData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("StageId", aData => (object)aData.stageId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static RoundData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (StageId)
		public static List<RoundData> GetDataListByStageId(
			long stageId)
		{
			return dataTable.GetDataList("StageId", (object)stageId);
		}
		#endregion
	}
}
