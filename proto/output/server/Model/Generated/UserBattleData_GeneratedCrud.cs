using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserBattleData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserBattleData> _collection = null;
		private static IMongoCollection<UserBattleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserBattleData>("user_battles"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserBattleData DbCreateNew()
		{
			var result = new UserBattleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserBattleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserBattleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserBattleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserBattleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserBattleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserBattleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserBattleData>.Filter;
				var model = new ReplaceOneModel<UserBattleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserBattleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserBattleData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.userId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserBattleData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserBattleData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserBattleData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserBattleData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserBattleData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserBattleData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserBattleData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserBattleData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserBattleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserBattleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region MongoDbIndex(UserId)
		public static async Task<UserBattleData> DbGetDataByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserBattleData#DbGetDataByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserBattleData>> DbGetDataListByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.ToListAsync();
			Console.WriteLine($"UserBattleData#DbGetDataListByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserBattleData>> DbGetDataListByUserIds(
			IEnumerable<long> userIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = userIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.userId))
				.ToListAsync();
			Console.WriteLine($"UserBattleData#DbGetDataListByUserIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByUserId(
			long userId)
		{
			var dataList = await DbGetDataListByUserId(userId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataByUserIds(
			IEnumerable<long> userIds)
		{
			var dataList = await DbGetDataListByUserIds(userIds);
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
