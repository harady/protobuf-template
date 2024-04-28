using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserItemData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserItemData> _collection = null;
		private static IMongoCollection<UserItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserItemData>("user_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserItemData DbCreateNew()
		{
			var result = new UserItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userItemTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserItemData>.Filter;
				var model = new ReplaceOneModel<UserItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userItemTableUpdate.Upsert(dataList); }
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserItemData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.userId));
			await DbSetupOneIndex(builder.Ascending(aData => aData.itemId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserItemData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserItemData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserItemData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserItemData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserItemData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserItemData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserItemData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserItemData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userItemTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userItemTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region MongoDbIndex(UserId)
		public static async Task<UserItemData> DbGetDataByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserItemData#DbGetDataByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserItemData>> DbGetDataListByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.ToListAsync();
			Console.WriteLine($"UserItemData#DbGetDataListByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserItemData>> DbGetDataListByUserIds(
			IEnumerable<long> userIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = userIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.userId))
				.ToListAsync();
			Console.WriteLine($"UserItemData#DbGetDataListByUserIds {sw.Elapsed.TotalSeconds}[秒]");
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
		#region MongoDbUniqueIndex(ItemId)
		public static async Task<UserItemData> DbGetDataByItemId(
			long itemId)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserItemData/GetDataByItemId_" + itemId;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.itemId == itemId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserItemData#DbGetDataByItemId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserItemData>> DbGetDataListInItemIds(
			IEnumerable<long> itemIds)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserItemData>.Filter.In(aData => aData.itemId, itemIds);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserItemData#DbGetDataListInItemIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByItemId(
			long itemId)
		{
			var data = await DbGetDataByItemId(itemId);
			var result = await DbDeleteDataById(data.id);
			return result;
		}

		public static async Task<bool> DbDeleteDataByItemIds(
			IEnumerable<long> itemIds)
		{
			var dataList = await DbGetDataListInItemIds(itemIds);
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
