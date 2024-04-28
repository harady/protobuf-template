using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ItemData> _collection = null;
		private static IMongoCollection<ItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ItemData>("items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ItemData DbCreateNew()
		{
			var result = new ItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ItemData>.Filter;
				var model = new ReplaceOneModel<ItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static ItemData Null => NullObjectContainer.Get<ItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ItemData> dataTable {
			get {
				DataTable<long, ItemData> result;
				if (GameDb.TableExists<long, ItemData>()) {
					result = GameDb.From<long, ItemData>();
				} else {
					result = GameDb.CreateTable<long, ItemData>();
					SetupItemDataTableIndexGenerated(result);
					SetupItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupItemDataTableIndex(DataTable<long, ItemData> targetDataTable);

		private static void SetupItemDataTableIndexGenerated(DataTable<long, ItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Category", aData => (object)aData.category);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Category)
		public static List<ItemData> GetDataListByCategory(
			ItemCategory category)
		{
			return dataTable.GetDataList("Category", (object)category);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<ItemData> GetDataListByType(
			ItemType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
	}
}
