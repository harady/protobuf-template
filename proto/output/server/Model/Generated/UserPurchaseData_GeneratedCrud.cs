using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserPurchaseData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserPurchaseData> _collection = null;
		private static IMongoCollection<UserPurchaseData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserPurchaseData>("user_purchases"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserPurchaseData DbCreateNew()
		{
			var result = new UserPurchaseData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserPurchaseData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserPurchaseData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserPurchaseData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserPurchaseData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserPurchaseData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserPurchaseData>.Filter;
				var model = new ReplaceOneModel<UserPurchaseData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserPurchaseData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserPurchaseData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.userId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserPurchaseData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserPurchaseData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserPurchaseData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserPurchaseData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserPurchaseData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserPurchaseData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserPurchaseData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserPurchaseData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region MongoDbIndex(UserId)
		public static async Task<UserPurchaseData> DbGetDataByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserPurchaseData>> DbGetDataListByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.ToListAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataListByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserPurchaseData>> DbGetDataListByUserIds(
			IEnumerable<long> userIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = userIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.userId))
				.ToListAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataListByUserIds {sw.Elapsed.TotalSeconds}[秒]");
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
