using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserGachaButtonData : IUnique<long>
	{
		private static bool isMaster => false;

		private static IMongoCollection<UserGachaButtonData> _collection = null;
		private static IMongoCollection<UserGachaButtonData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserGachaButtonData>("user_gacha_buttons"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserGachaButtonData DbCreateNew()
		{
			var result = new UserGachaButtonData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserGachaButtonData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserGachaButtonData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserGachaButtonData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userGachaButtonTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserGachaButtonData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserGachaButtonData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserGachaButtonData>.Filter;
				var model = new ReplaceOneModel<UserGachaButtonData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserGachaButtonData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userGachaButtonTableUpdate.Upsert(dataList); }
			return result;
		}
		#endregion
		#region DataTableSetupIndex
		public static async Task DbSetupIndex()
		{
			var builder = Builders<UserGachaButtonData>.IndexKeys;
			await DbSetupOneIndex(builder.Ascending(aData => aData.userId));
			await DbSetupOneIndex(builder.Ascending(aData => aData.gachaButtonId));
			await DbSetupOneIndex(builder.Ascending(aData => aData.gachaScheduleId));
		}

		public static async Task DbSetupOneIndex(
			IndexKeysDefinition<UserGachaButtonData> indexKeys)
		{
			var indexModel = new CreateIndexModel<UserGachaButtonData>(indexKeys);
			await collection.Indexes
				.CreateOneAsync(
					sessionHandle,
					indexModel);
		}
		#endregion
		#region MongoDbUniqueIndex(Id)
		public static async Task<UserGachaButtonData> DbGetDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var cacheKey = "UserGachaButtonData/GetDataById_" + id;
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.id == id)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataById {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserGachaButtonData>> DbGetDataListInIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var filter = Builders<UserGachaButtonData>.Filter.In(aData => aData.id, ids);
			var result = await collection
				.Find(
					sessionHandle,
					filter)
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListInIds {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserGachaButtonData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userGachaButtonTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserGachaButtonData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userGachaButtonTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region MongoDbIndex(UserId)
		public static async Task<UserGachaButtonData> DbGetDataByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserGachaButtonData>> DbGetDataListByUserId(
			long userId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.userId == userId)
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListByUserId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserGachaButtonData>> DbGetDataListByUserIds(
			IEnumerable<long> userIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = userIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.userId))
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListByUserIds {sw.Elapsed.TotalSeconds}[秒]");
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
		#region MongoDbIndex(GachaButtonId)
		public static async Task<UserGachaButtonData> DbGetDataByGachaButtonId(
			long gachaButtonId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.gachaButtonId == gachaButtonId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataByGachaButtonId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserGachaButtonData>> DbGetDataListByGachaButtonId(
			long gachaButtonId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.gachaButtonId == gachaButtonId)
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListByGachaButtonId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserGachaButtonData>> DbGetDataListByGachaButtonIds(
			IEnumerable<long> gachaButtonIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = gachaButtonIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.gachaButtonId))
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListByGachaButtonIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByGachaButtonId(
			long gachaButtonId)
		{
			var dataList = await DbGetDataListByGachaButtonId(gachaButtonId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataByGachaButtonIds(
			IEnumerable<long> gachaButtonIds)
		{
			var dataList = await DbGetDataListByGachaButtonIds(gachaButtonIds);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}
		#endregion
		#region MongoDbIndex(GachaScheduleId)
		public static async Task<UserGachaButtonData> DbGetDataByGachaScheduleId(
			long gachaScheduleId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.gachaScheduleId == gachaScheduleId)
				.FirstOrDefaultAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataByGachaScheduleId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<List<UserGachaButtonData>> DbGetDataListByGachaScheduleId(
			long gachaScheduleId)
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					aData => aData.gachaScheduleId == gachaScheduleId)
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListByGachaScheduleId {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}
		
		public static async Task<List<UserGachaButtonData>> DbGetDataListByGachaScheduleIds(
			IEnumerable<long> gachaScheduleIds)
		{
			var sw = Stopwatch.StartNew();
			var keySet = gachaScheduleIds.ToHashSet();
			var result = await collection
				.Find(
					sessionHandle,
					data => keySet.Contains(data.gachaScheduleId))
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataListByGachaScheduleIds {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbDeleteDataByGachaScheduleId(
			long gachaScheduleId)
		{
			var dataList = await DbGetDataListByGachaScheduleId(gachaScheduleId);
			var ids = dataList.Select(data => data.id);
			var result = await DbDeleteDataByIds(ids);
			return result;
		}

		public static async Task<bool> DbDeleteDataByGachaScheduleIds(
			IEnumerable<long> gachaScheduleIds)
		{
			var dataList = await DbGetDataListByGachaScheduleIds(gachaScheduleIds);
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
