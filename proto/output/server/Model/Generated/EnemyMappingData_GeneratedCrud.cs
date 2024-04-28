using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class EnemyMappingData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<EnemyMappingData> _collection = null;
		private static IMongoCollection<EnemyMappingData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<EnemyMappingData>("enemy_mappings"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static EnemyMappingData DbCreateNew()
		{
			var result = new EnemyMappingData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<EnemyMappingData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"EnemyMappingData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			EnemyMappingData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"EnemyMappingData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<EnemyMappingData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<EnemyMappingData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<EnemyMappingData>.Filter;
				var model = new ReplaceOneModel<EnemyMappingData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"EnemyMappingData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EnemyMappingData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EnemyMappingData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static EnemyMappingData Null => NullObjectContainer.Get<EnemyMappingData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, EnemyMappingData> dataTable {
			get {
				DataTable<long, EnemyMappingData> result;
				if (GameDb.TableExists<long, EnemyMappingData>()) {
					result = GameDb.From<long, EnemyMappingData>();
				} else {
					result = GameDb.CreateTable<long, EnemyMappingData>();
					SetupEnemyMappingDataTableIndexGenerated(result);
					SetupEnemyMappingDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<EnemyMappingData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<EnemyMappingData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupEnemyMappingDataTableIndex(DataTable<long, EnemyMappingData> targetDataTable);

		private static void SetupEnemyMappingDataTableIndexGenerated(DataTable<long, EnemyMappingData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("RoundId", aData => (object)aData.roundId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static EnemyMappingData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (RoundId)
		public static List<EnemyMappingData> GetDataListByRoundId(
			long roundId)
		{
			return dataTable.GetDataList("RoundId", (object)roundId);
		}
		#endregion
	}
}
