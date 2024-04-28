using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserFriendRequestData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserFriendRequestData> _collection = null;
		private static IMongoCollection<UserFriendRequestData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserFriendRequestData>("user_friend_requests"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserFriendRequestData DbCreateNew()
		{
			var result = new UserFriendRequestData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserFriendRequestData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserFriendRequestData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserFriendRequestData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserFriendRequestData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserFriendRequestData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserFriendRequestData>.Filter;
				var model = new ReplaceOneModel<UserFriendRequestData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserFriendRequestData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserFriendRequestData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.senderUserId));
			await DbSetupOneIndex(builder.Ascending(aData => aData.targetUserId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserFriendRequestData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserFriendRequestData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserFriendRequestData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserFriendRequestData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserFriendRequestData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserFriendRequestData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserFriendRequestData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserFriendRequestData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region MongoDbIndex(SenderUserId)
		public static async Task<UserFriendRequestData> DbGetDataBySenderUserId(
			long senderUserId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.senderUserId == senderUserId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataBySenderUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserFriendRequestData>> DbGetDataListBySenderUserId(
			long senderUserId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.senderUserId == senderUserId)
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataListBySenderUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserFriendRequestData>> DbGetDataListBySenderUserIds(
			IEnumerable<long> senderUserIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = senderUserIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.senderUserId))
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataListBySenderUserIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataBySenderUserId(
			long senderUserId)
		{
			var dataList = await DbGetDataListBySenderUserId(senderUserId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataBySenderUserIds(
			IEnumerable<long> senderUserIds)
		{
			var dataList = await DbGetDataListBySenderUserIds(senderUserIds);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}
		#endregion
		#region MongoDbIndex(TargetUserId)
		public static async Task<UserFriendRequestData> DbGetDataByTargetUserId(
			long targetUserId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.targetUserId == targetUserId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataByTargetUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserFriendRequestData>> DbGetDataListByTargetUserId(
			long targetUserId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.targetUserId == targetUserId)
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataListByTargetUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserFriendRequestData>> DbGetDataListByTargetUserIds(
			IEnumerable<long> targetUserIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = targetUserIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.targetUserId))
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataListByTargetUserIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByTargetUserId(
			long targetUserId)
		{
			var dataList = await DbGetDataListByTargetUserId(targetUserId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataByTargetUserIds(
			IEnumerable<long> targetUserIds)
		{
			var dataList = await DbGetDataListByTargetUserIds(targetUserIds);
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
