using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ResourceLotteryData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ResourceLotteryData> _collection = null;
		private static IMongoCollection<ResourceLotteryData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ResourceLotteryData>("resource_lotterys"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ResourceLotteryData DbCreateNew()
		{
			var result = new ResourceLotteryData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ResourceLotteryData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ResourceLotteryData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ResourceLotteryData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ResourceLotteryData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ResourceLotteryData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ResourceLotteryData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ResourceLotteryData>.Filter;
				var model = new ReplaceOneModel<ResourceLotteryData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ResourceLotteryData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ResourceLotteryData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ResourceLotteryData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static ResourceLotteryData Null => NullObjectContainer.Get<ResourceLotteryData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ResourceLotteryData> dataTable {
			get {
				DataTable<long, ResourceLotteryData> result;
				if (GameDb.TableExists<long, ResourceLotteryData>()) {
					result = GameDb.From<long, ResourceLotteryData>();
				} else {
					result = GameDb.CreateTable<long, ResourceLotteryData>();
					SetupResourceLotteryDataTableIndexGenerated(result);
					SetupResourceLotteryDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ResourceLotteryData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ResourceLotteryData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupResourceLotteryDataTableIndex(DataTable<long, ResourceLotteryData> targetDataTable);

		private static void SetupResourceLotteryDataTableIndexGenerated(DataTable<long, ResourceLotteryData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ResourceLotteryData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
	}
}
