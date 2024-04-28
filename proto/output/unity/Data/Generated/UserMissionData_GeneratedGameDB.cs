using System.Collections.Generic;

public partial class UserMissionData : IUnique<long>
{
	#region NullObject
	public static UserMissionData Null => NullObjectContainer.Get<UserMissionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserMissionData> dataTable {
		get {
			DataTable<long, UserMissionData> result;
			if (GameDb.TableExists<long, UserMissionData>()) {
				result = GameDb.From<long, UserMissionData>();
			} else {
				result = GameDb.CreateTable<long, UserMissionData>();
				SetupUserMissionDataTableIndexGenerated(result);
				SetupUserMissionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserMissionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserMissionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserMissionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserMissionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserMissionDataTableIndex(DataTable<long, UserMissionData> targetDataTable);

	private static void SetupUserMissionDataTableIndexGenerated(DataTable<long, UserMissionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserMissionData GetDataById(long id)
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
	#region DataTableIndex (UserId)
	public static List<UserMissionData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
}

