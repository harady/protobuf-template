using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ShopItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ShopItemData> _collection = null;
		private static IMongoCollection<ShopItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ShopItemData>("shop_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ShopItemData DbCreateNew()
		{
			var result = new ShopItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ShopItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ShopItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ShopItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ShopItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ShopItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ShopItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ShopItemData>.Filter;
				var model = new ReplaceOneModel<ShopItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ShopItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ShopItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ShopItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static ShopItemData Null => NullObjectContainer.Get<ShopItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ShopItemData> dataTable {
			get {
				DataTable<long, ShopItemData> result;
				if (GameDb.TableExists<long, ShopItemData>()) {
					result = GameDb.From<long, ShopItemData>();
				} else {
					result = GameDb.CreateTable<long, ShopItemData>();
					SetupShopItemDataTableIndexGenerated(result);
					SetupShopItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ShopItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ShopItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupShopItemDataTableIndex(DataTable<long, ShopItemData> targetDataTable);

		private static void SetupShopItemDataTableIndexGenerated(DataTable<long, ShopItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateUniqueIndex("PlatformProductId", aData => (object)aData.platformProductId);
			targetDataTable.CreateIndex("ShopId", aData => (object)aData.shopId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ShopItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableUniqueIndex(PlatformProductId)
		public static ShopItemData GetDataByPlatformProductId(
			string platformProductId)
		{
			return dataTable.GetData("PlatformProductId", (object)platformProductId);
		}
		#endregion
		#region DataTableIndex (ShopId)
		public static List<ShopItemData> GetDataListByShopId(
			long shopId)
		{
			return dataTable.GetDataList("ShopId", (object)shopId);
		}
		#endregion
	}
}
