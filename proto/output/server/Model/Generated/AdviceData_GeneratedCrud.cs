using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class AdviceData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<AdviceData> _collection = null;
		private static IMongoCollection<AdviceData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<AdviceData>("advices"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static AdviceData DbCreateNew()
		{
			var result = new AdviceData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<AdviceData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"AdviceData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			AdviceData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"AdviceData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<AdviceData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<AdviceData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<AdviceData>.Filter;
				var model = new ReplaceOneModel<AdviceData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"AdviceData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"AdviceData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"AdviceData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static AdviceData Null => NullObjectContainer.Get<AdviceData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, AdviceData> dataTable {
			get {
				DataTable<long, AdviceData> result;
				if (GameDb.TableExists<long, AdviceData>()) {
					result = GameDb.From<long, AdviceData>();
				} else {
					result = GameDb.CreateTable<long, AdviceData>();
					SetupAdviceDataTableIndexGenerated(result);
					SetupAdviceDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<AdviceData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<AdviceData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupAdviceDataTableIndex(DataTable<long, AdviceData> targetDataTable);

		private static void SetupAdviceDataTableIndexGenerated(DataTable<long, AdviceData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static AdviceData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
	}
}
