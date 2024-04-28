using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserRankExpData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserRankExpData> _collection = null;
		private static IMongoCollection<UserRankExpData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserRankExpData>("user_rank_exps"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserRankExpData DbCreateNew()
		{
			var result = new UserRankExpData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserRankExpData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserRankExpData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserRankExpData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserRankExpData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserRankExpData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserRankExpData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserRankExpData>.Filter;
				var model = new ReplaceOneModel<UserRankExpData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserRankExpData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserRankExpData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UserRankExpData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static UserRankExpData Null => NullObjectContainer.Get<UserRankExpData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserRankExpData> dataTable {
			get {
				DataTable<long, UserRankExpData> result;
				if (GameDb.TableExists<long, UserRankExpData>()) {
					result = GameDb.From<long, UserRankExpData>();
				} else {
					result = GameDb.CreateTable<long, UserRankExpData>();
					SetupUserRankExpDataTableIndexGenerated(result);
					SetupUserRankExpDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserRankExpData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserRankExpData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserRankExpDataTableIndex(DataTable<long, UserRankExpData> targetDataTable);

		private static void SetupUserRankExpDataTableIndexGenerated(DataTable<long, UserRankExpData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateUniqueIndex("Rank", aData => (object)aData.rank);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserRankExpData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableUniqueIndex(Rank)
		public static UserRankExpData GetDataByRank(
			long rank)
		{
			return dataTable.GetData("Rank", (object)rank);
		}
		#endregion
	}
}
