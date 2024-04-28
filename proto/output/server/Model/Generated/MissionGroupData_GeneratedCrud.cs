using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class MissionGroupData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<MissionGroupData> _collection = null;
		private static IMongoCollection<MissionGroupData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<MissionGroupData>("mission_groups"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static MissionGroupData DbCreateNew()
		{
			var result = new MissionGroupData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<MissionGroupData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"MissionGroupData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			MissionGroupData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"MissionGroupData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<MissionGroupData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<MissionGroupData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<MissionGroupData>.Filter;
				var model = new ReplaceOneModel<MissionGroupData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"MissionGroupData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"MissionGroupData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"MissionGroupData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static MissionGroupData Null => NullObjectContainer.Get<MissionGroupData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, MissionGroupData> dataTable {
			get {
				DataTable<long, MissionGroupData> result;
				if (GameDb.TableExists<long, MissionGroupData>()) {
					result = GameDb.From<long, MissionGroupData>();
				} else {
					result = GameDb.CreateTable<long, MissionGroupData>();
					SetupMissionGroupDataTableIndexGenerated(result);
					SetupMissionGroupDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<MissionGroupData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<MissionGroupData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupMissionGroupDataTableIndex(DataTable<long, MissionGroupData> targetDataTable);

		private static void SetupMissionGroupDataTableIndexGenerated(DataTable<long, MissionGroupData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static MissionGroupData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<MissionGroupData> GetDataListByType(
			MissionGroupType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
	}
}
