using System.Collections.Generic;

public partial class UserFriendData : IUnique<long>
{
	#region NullObject
	public static UserFriendData Null => NullObjectContainer.Get<UserFriendData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserFriendData> dataTable {
		get {
			DataTable<long, UserFriendData> result;
			if (GameDb.TableExists<long, UserFriendData>()) {
				result = GameDb.From<long, UserFriendData>();
			} else {
				result = GameDb.CreateTable<long, UserFriendData>();
				SetupUserFriendDataTableIndexGenerated(result);
				SetupUserFriendDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserFriendData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserFriendData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserFriendData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserFriendData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserFriendDataTableIndex(DataTable<long, UserFriendData> targetDataTable);

	private static void SetupUserFriendDataTableIndexGenerated(DataTable<long, UserFriendData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
		targetDataTable.CreateIndex("FriendUserId", aData => (object)aData.friendUserId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserFriendData GetDataById(long id)
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
	public static List<UserFriendData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
	#region DataTableIndex (FriendUserId)
	public static List<UserFriendData> GetDataListByFriendUserId(long friendUserId)
	{
		return dataTable.GetDataList("FriendUserId", (object)friendUserId);
	}
	#endregion
}

