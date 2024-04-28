using System.Collections.Generic;

public partial class UserStageData : IUnique<long>
{
	#region NullObject
	public static UserStageData Null => NullObjectContainer.Get<UserStageData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserStageData> dataTable {
		get {
			DataTable<long, UserStageData> result;
			if (GameDb.TableExists<long, UserStageData>()) {
				result = GameDb.From<long, UserStageData>();
			} else {
				result = GameDb.CreateTable<long, UserStageData>();
				SetupUserStageDataTableIndexGenerated(result);
				SetupUserStageDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserStageData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserStageData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserStageData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserStageData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserStageDataTableIndex(DataTable<long, UserStageData> targetDataTable);

	private static void SetupUserStageDataTableIndexGenerated(DataTable<long, UserStageData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateUniqueIndex("StageId", aData => (object)aData.stageId);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserStageData GetDataById(long id)
	{
		return dataTable.GetData("Id", (object)id);
	}

	public static void RemoveDataByIds(ICollection<long> ids)
	{
		ids.ForEach(aId => RemoveDataById(aId));
	}

	public static void RemoveDataById(long id)
	{
		dataTable.DeleteByKey("Id", (object)id);
	}
	#endregion
	#region DataTableUniqueIndex(StageId)
	public static UserStageData GetDataByStageId(long stageId)
	{
		return dataTable.GetData("StageId", (object)stageId);
	}

	public static void RemoveDataByStageIds(ICollection<long> stageIds)
	{
		stageIds.ForEach(aStageId => RemoveDataByStageId(aStageId));
	}

	public static void RemoveDataByStageId(long stageId)
	{
		dataTable.DeleteByKey("StageId", (object)stageId);
	}
	#endregion
	#region DataTableIndex (UserId)
	public static List<UserStageData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
}

