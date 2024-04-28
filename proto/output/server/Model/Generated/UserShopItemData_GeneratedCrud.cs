using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserShopItemData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserShopItemData> _collection = null;
		private static IMongoCollection<UserShopItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserShopItemData>("user_shop_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserShopItemData DbCreateNew()
		{
			var result = new UserShopItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserShopItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserShopItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserShopItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userShopItemTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserShopItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserShopItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserShopItemData>.Filter;
				var model = new ReplaceOneModel<UserShopItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserShopItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userShopItemTableUpdate.Upsert(dataList); }
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserShopItemData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.userId));
			await DbSetupOneIndex(builder.Ascending(aData => aData.shopItemId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserShopItemData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserShopItemData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserShopItemData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserShopItemData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserShopItemData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserShopItemData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserShopItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userShopItemTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserShopItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userShopItemTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region MongoDbIndex(UserId)
		public static async Task<UserShopItemData> DbGetDataByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserShopItemData>> DbGetDataListByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataListByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserShopItemData>> DbGetDataListByUserIds(
			IEnumerable<long> userIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = userIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.userId))
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataListByUserIds {sw.Elapsed.TotalSeconds}[秒]");
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
		#region MongoDbIndex(ShopItemId)
		public static async Task<UserShopItemData> DbGetDataByShopItemId(
			long shopItemId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.shopItemId == shopItemId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataByShopItemId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserShopItemData>> DbGetDataListByShopItemId(
			long shopItemId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.shopItemId == shopItemId)
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataListByShopItemId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserShopItemData>> DbGetDataListByShopItemIds(
			IEnumerable<long> shopItemIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = shopItemIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.shopItemId))
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataListByShopItemIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByShopItemId(
			long shopItemId)
		{
			var dataList = await DbGetDataListByShopItemId(shopItemId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataByShopItemIds(
			IEnumerable<long> shopItemIds)
		{
			var dataList = await DbGetDataListByShopItemIds(shopItemIds);
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
