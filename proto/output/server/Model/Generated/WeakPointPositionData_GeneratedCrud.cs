using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class WeakPointPositionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<WeakPointPositionData> _collection = null;
		private static IMongoCollection<WeakPointPositionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<WeakPointPositionData>("weak_point_positions"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static WeakPointPositionData DbCreateNew()
		{
			var result = new WeakPointPositionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<WeakPointPositionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"WeakPointPositionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			WeakPointPositionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"WeakPointPositionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<WeakPointPositionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<WeakPointPositionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<WeakPointPositionData>.Filter;
				var model = new ReplaceOneModel<WeakPointPositionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"WeakPointPositionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"WeakPointPositionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"WeakPointPositionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static WeakPointPositionData Null => NullObjectContainer.Get<WeakPointPositionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, WeakPointPositionData> dataTable {
			get {
				DataTable<long, WeakPointPositionData> result;
				if (GameDb.TableExists<long, WeakPointPositionData>()) {
					result = GameDb.From<long, WeakPointPositionData>();
				} else {
					result = GameDb.CreateTable<long, WeakPointPositionData>();
					SetupWeakPointPositionDataTableIndexGenerated(result);
					SetupWeakPointPositionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<WeakPointPositionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<WeakPointPositionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupWeakPointPositionDataTableIndex(DataTable<long, WeakPointPositionData> targetDataTable);

		private static void SetupWeakPointPositionDataTableIndexGenerated(DataTable<long, WeakPointPositionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("WeakPointId", aData => (object)aData.weakPointId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static WeakPointPositionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (WeakPointId)
		public static List<WeakPointPositionData> GetDataListByWeakPointId(
			long weakPointId)
		{
			return dataTable.GetDataList("WeakPointId", (object)weakPointId);
		}
		#endregion
	}
}
