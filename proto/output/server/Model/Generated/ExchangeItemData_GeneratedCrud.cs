using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ExchangeItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ExchangeItemData> _collection = null;
		private static IMongoCollection<ExchangeItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ExchangeItemData>("exchange_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ExchangeItemData DbCreateNew()
		{
			var result = new ExchangeItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ExchangeItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ExchangeItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ExchangeItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ExchangeItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ExchangeItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ExchangeItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ExchangeItemData>.Filter;
				var model = new ReplaceOneModel<ExchangeItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ExchangeItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ExchangeItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"ExchangeItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static ExchangeItemData Null => NullObjectContainer.Get<ExchangeItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ExchangeItemData> dataTable {
			get {
				DataTable<long, ExchangeItemData> result;
				if (GameDb.TableExists<long, ExchangeItemData>()) {
					result = GameDb.From<long, ExchangeItemData>();
				} else {
					result = GameDb.CreateTable<long, ExchangeItemData>();
					SetupExchangeItemDataTableIndexGenerated(result);
					SetupExchangeItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ExchangeItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ExchangeItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupExchangeItemDataTableIndex(DataTable<long, ExchangeItemData> targetDataTable);

		private static void SetupExchangeItemDataTableIndexGenerated(DataTable<long, ExchangeItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("ExchangeId", aData => (object)aData.exchangeId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ExchangeItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (ExchangeId)
		public static List<ExchangeItemData> GetDataListByExchangeId(
			long exchangeId)
		{
			return dataTable.GetDataList("ExchangeId", (object)exchangeId);
		}
		#endregion
	}
}
