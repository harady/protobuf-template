using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class LoginBonusData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<LoginBonusData> _collection = null;
		private static IMongoCollection<LoginBonusData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<LoginBonusData>("login_bonuss"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static LoginBonusData DbCreateNew()
		{
			var result = new LoginBonusData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<LoginBonusData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"LoginBonusData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			LoginBonusData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"LoginBonusData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<LoginBonusData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<LoginBonusData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<LoginBonusData>.Filter;
				var model = new ReplaceOneModel<LoginBonusData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"LoginBonusData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"LoginBonusData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"LoginBonusData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static LoginBonusData Null => NullObjectContainer.Get<LoginBonusData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, LoginBonusData> dataTable {
			get {
				DataTable<long, LoginBonusData> result;
				if (GameDb.TableExists<long, LoginBonusData>()) {
					result = GameDb.From<long, LoginBonusData>();
				} else {
					result = GameDb.CreateTable<long, LoginBonusData>();
					SetupLoginBonusDataTableIndexGenerated(result);
					SetupLoginBonusDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<LoginBonusData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<LoginBonusData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupLoginBonusDataTableIndex(DataTable<long, LoginBonusData> targetDataTable);

		private static void SetupLoginBonusDataTableIndexGenerated(DataTable<long, LoginBonusData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static LoginBonusData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
	}
}
