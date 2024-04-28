using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ResourceSetItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ResourceSetItemData> _collection = null;
		private static IMongoCollection<ResourceSetItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ResourceSetItemData>("resource_set_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ResourceSetItemData DbCreateNew()
		{
			var result = new ResourceSetItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ResourceSetItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ResourceSetItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ResourceSetItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ResourceSetItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ResourceSetItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ResourceSetItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ResourceSetItemData>.Filter;
				var model = new ReplaceOneModel<ResourceSetItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ResourceSetItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ResourceSetItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ResourceSetItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static ResourceSetItemData Null => NullObjectContainer.Get<ResourceSetItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ResourceSetItemData> dataTable {
			get {
				DataTable<long, ResourceSetItemData> result;
				if (GameDb.TableExists<long, ResourceSetItemData>()) {
					result = GameDb.From<long, ResourceSetItemData>();
				} else {
					result = GameDb.CreateTable<long, ResourceSetItemData>();
					SetupResourceSetItemDataTableIndexGenerated(result);
					SetupResourceSetItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ResourceSetItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ResourceSetItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupResourceSetItemDataTableIndex(DataTable<long, ResourceSetItemData> targetDataTable);

		private static void SetupResourceSetItemDataTableIndexGenerated(DataTable<long, ResourceSetItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("ResourceSetId", aData => (object)aData.resourceSetId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ResourceSetItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (ResourceSetId)
		public static List<ResourceSetItemData> GetDataListByResourceSetId(
			long resourceSetId)
		{
			return dataTable.GetDataList("ResourceSetId", (object)resourceSetId);
		}
		#endregion
	}
}
