using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ShopScheduleData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ShopScheduleData> _collection = null;
		private static IMongoCollection<ShopScheduleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ShopScheduleData>("shop_schedules"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ShopScheduleData DbCreateNew()
		{
			var result = new ShopScheduleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ShopScheduleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ShopScheduleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ShopScheduleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ShopScheduleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ShopScheduleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ShopScheduleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ShopScheduleData>.Filter;
				var model = new ReplaceOneModel<ShopScheduleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ShopScheduleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ShopScheduleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ShopScheduleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static ShopScheduleData Null => NullObjectContainer.Get<ShopScheduleData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ShopScheduleData> dataTable {
			get {
				DataTable<long, ShopScheduleData> result;
				if (GameDb.TableExists<long, ShopScheduleData>()) {
					result = GameDb.From<long, ShopScheduleData>();
				} else {
					result = GameDb.CreateTable<long, ShopScheduleData>();
					SetupShopScheduleDataTableIndexGenerated(result);
					SetupShopScheduleDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ShopScheduleData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ShopScheduleData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupShopScheduleDataTableIndex(DataTable<long, ShopScheduleData> targetDataTable);

		private static void SetupShopScheduleDataTableIndexGenerated(DataTable<long, ShopScheduleData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("ShopId", aData => (object)aData.shopId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ShopScheduleData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (ShopId)
		public static List<ShopScheduleData> GetDataListByShopId(
			long shopId)
		{
			return dataTable.GetDataList("ShopId", (object)shopId);
		}
		#endregion
	}
}
