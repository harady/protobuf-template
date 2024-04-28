using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UnitLevelExpData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UnitLevelExpData> _collection = null;
		private static IMongoCollection<UnitLevelExpData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UnitLevelExpData>("unit_level_exps"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UnitLevelExpData DbCreateNew()
		{
			var result = new UnitLevelExpData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UnitLevelExpData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UnitLevelExpData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UnitLevelExpData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UnitLevelExpData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UnitLevelExpData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UnitLevelExpData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UnitLevelExpData>.Filter;
				var model = new ReplaceOneModel<UnitLevelExpData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UnitLevelExpData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UnitLevelExpData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UnitLevelExpData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static UnitLevelExpData Null => NullObjectContainer.Get<UnitLevelExpData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UnitLevelExpData> dataTable {
			get {
				DataTable<long, UnitLevelExpData> result;
				if (GameDb.TableExists<long, UnitLevelExpData>()) {
					result = GameDb.From<long, UnitLevelExpData>();
				} else {
					result = GameDb.CreateTable<long, UnitLevelExpData>();
					SetupUnitLevelExpDataTableIndexGenerated(result);
					SetupUnitLevelExpDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UnitLevelExpData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UnitLevelExpData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUnitLevelExpDataTableIndex(DataTable<long, UnitLevelExpData> targetDataTable);

		private static void SetupUnitLevelExpDataTableIndexGenerated(DataTable<long, UnitLevelExpData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("GrowthType", aData => (object)aData.growthType);
			targetDataTable.CreateIndex("Level", aData => (object)aData.level);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UnitLevelExpData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (GrowthType)
		public static List<UnitLevelExpData> GetDataListByGrowthType(
			long growthType)
		{
			return dataTable.GetDataList("GrowthType", (object)growthType);
		}
		#endregion
		#region DataTableIndex (Level)
		public static List<UnitLevelExpData> GetDataListByLevel(
			long level)
		{
			return dataTable.GetDataList("Level", (object)level);
		}
		#endregion
	}
}
