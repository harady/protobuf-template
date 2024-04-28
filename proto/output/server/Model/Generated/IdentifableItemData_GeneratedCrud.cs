using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class IdentifableItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<IdentifableItemData> _collection = null;
		private static IMongoCollection<IdentifableItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<IdentifableItemData>("identifable_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static IdentifableItemData DbCreateNew()
		{
			var result = new IdentifableItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<IdentifableItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"IdentifableItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			IdentifableItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"IdentifableItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<IdentifableItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<IdentifableItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<IdentifableItemData>.Filter;
				var model = new ReplaceOneModel<IdentifableItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"IdentifableItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"IdentifableItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"IdentifableItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static IdentifableItemData Null => NullObjectContainer.Get<IdentifableItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, IdentifableItemData> dataTable {
			get {
				DataTable<long, IdentifableItemData> result;
				if (GameDb.TableExists<long, IdentifableItemData>()) {
					result = GameDb.From<long, IdentifableItemData>();
				} else {
					result = GameDb.CreateTable<long, IdentifableItemData>();
					SetupIdentifableItemDataTableIndexGenerated(result);
					SetupIdentifableItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<IdentifableItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<IdentifableItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupIdentifableItemDataTableIndex(DataTable<long, IdentifableItemData> targetDataTable);

		private static void SetupIdentifableItemDataTableIndexGenerated(DataTable<long, IdentifableItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static IdentifableItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<IdentifableItemData> GetDataListByType(
			IdentifableItemType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
	}
}
