using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class BattleInitEnemyData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<BattleInitEnemyData> _collection = null;
		private static IMongoCollection<BattleInitEnemyData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<BattleInitEnemyData>("battle_init_enemys"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static BattleInitEnemyData DbCreateNew()
		{
			var result = new BattleInitEnemyData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<BattleInitEnemyData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			BattleInitEnemyData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"BattleInitEnemyData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<BattleInitEnemyData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<BattleInitEnemyData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<BattleInitEnemyData>.Filter;
				var model = new ReplaceOneModel<BattleInitEnemyData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"BattleInitEnemyData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<BattleInitEnemyData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.roundId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<BattleInitEnemyData> indexKeys)
		{
			var indexModel = new CreateIndexModel<BattleInitEnemyData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<BattleInitEnemyData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "BattleInitEnemyData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<BattleInitEnemyData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<BattleInitEnemyData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var deleteResult = await collection
				.DeleteOneAsync(
					sessionHandle,
					aData => aData.id == id);
			Console.WriteLine($"BattleInitEnemyData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"BattleInitEnemyData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region MongoDbIndex(RoundId)
		public static async Task<BattleInitEnemyData> DbGetDataByRoundId(
			long roundId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.roundId == roundId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataByRoundId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<BattleInitEnemyData>> DbGetDataListByRoundId(
			long roundId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.roundId == roundId)
				.ToListAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataListByRoundId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<BattleInitEnemyData>> DbGetDataListByRoundIds(
			IEnumerable<long> roundIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = roundIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.roundId))
				.ToListAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataListByRoundIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByRoundId(
			long roundId)
		{
			var dataList = await DbGetDataListByRoundId(roundId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataByRoundIds(
			IEnumerable<long> roundIds)
		{
			var dataList = await DbGetDataListByRoundIds(roundIds);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}
		#endregion
		#region Methods
		public async Task<bool> DbSave()
		{
			if (this._id == ObjectId.Empty) {
				var data = await DbGetDataById(this.id);
				this._id = (data != null) ? data._id : this._id;
			}
			return await DbSetData(this);
		}

		public async Task<bool> DbDelete()
		{
			return await DbDeleteDataById(this.id);
		}
		#endregion
	}
}
