using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class MissionScheduleData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<MissionScheduleData> _collection = null;
		private static IMongoCollection<MissionScheduleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<MissionScheduleData>("mission_schedules"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static MissionScheduleData DbCreateNew()
		{
			var result = new MissionScheduleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<MissionScheduleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"MissionScheduleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			MissionScheduleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"MissionScheduleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<MissionScheduleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<MissionScheduleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<MissionScheduleData>.Filter;
				var model = new ReplaceOneModel<MissionScheduleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"MissionScheduleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"MissionScheduleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"MissionScheduleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static MissionScheduleData Null => NullObjectContainer.Get<MissionScheduleData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, MissionScheduleData> dataTable {
			get {
				DataTable<long, MissionScheduleData> result;
				if (GameDb.TableExists<long, MissionScheduleData>()) {
					result = GameDb.From<long, MissionScheduleData>();
				} else {
					result = GameDb.CreateTable<long, MissionScheduleData>();
					SetupMissionScheduleDataTableIndexGenerated(result);
					SetupMissionScheduleDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<MissionScheduleData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<MissionScheduleData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupMissionScheduleDataTableIndex(DataTable<long, MissionScheduleData> targetDataTable);

		private static void SetupMissionScheduleDataTableIndexGenerated(DataTable<long, MissionScheduleData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static MissionScheduleData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
	}
}
