using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserSessionData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserSessionData> _collection = null;
		private static IMongoCollection<UserSessionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserSessionData>("user_sessions"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserSessionData DbCreateNew()
		{
			var result = new UserSessionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserSessionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserSessionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserSessionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserSessionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserSessionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserSessionData>.Filter;
				var model = new ReplaceOneModel<UserSessionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserSessionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserSessionData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.userId));
			await DbSetupOneIndex(builder.Ascending(aData => aData.sessionId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserSessionData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserSessionData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserSessionData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserSessionData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserSessionData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserSessionData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserSessionData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserSessionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserSessionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region MongoDbIndex(UserId)
		public static async Task<UserSessionData> DbGetDataByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserSessionData#DbGetDataByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserSessionData>> DbGetDataListByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataListByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserSessionData>> DbGetDataListByUserIds(
			IEnumerable<long> userIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = userIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.userId))
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataListByUserIds {sw.Elapsed.TotalSeconds}[秒]");
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
		#region MongoDbIndex(SessionId)
		public static async Task<UserSessionData> DbGetDataBySessionId(
			string sessionId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.sessionId == sessionId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserSessionData#DbGetDataBySessionId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserSessionData>> DbGetDataListBySessionId(
			string sessionId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.sessionId == sessionId)
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataListBySessionId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserSessionData>> DbGetDataListBySessionIds(
			IEnumerable<string> sessionIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = sessionIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.sessionId))
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataListBySessionIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataBySessionId(
			string sessionId)
		{
			var dataList = await DbGetDataListBySessionId(sessionId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataBySessionIds(
			IEnumerable<string> sessionIds)
		{
			var dataList = await DbGetDataListBySessionIds(sessionIds);
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
