using System.Collections.Generic;

public partial class UserFriendRequestData : IUnique<long>
{
	#region NullObject
	public static UserFriendRequestData Null => NullObjectContainer.Get<UserFriendRequestData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserFriendRequestData> dataTable {
		get {
			DataTable<long, UserFriendRequestData> result;
			if (GameDb.TableExists<long, UserFriendRequestData>()) {
				result = GameDb.From<long, UserFriendRequestData>();
			} else {
				result = GameDb.CreateTable<long, UserFriendRequestData>();
				SetupUserFriendRequestDataTableIndexGenerated(result);
				SetupUserFriendRequestDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserFriendRequestData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserFriendRequestData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserFriendRequestData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserFriendRequestData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserFriendRequestDataTableIndex(DataTable<long, UserFriendRequestData> targetDataTable);

	private static void SetupUserFriendRequestDataTableIndexGenerated(DataTable<long, UserFriendRequestData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("SenderUserId", aData => (object)aData.senderUserId);
		targetDataTable.CreateIndex("TargetUserId", aData => (object)aData.targetUserId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserFriendRequestData GetDataById(long id)
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
	#region DataTableIndex (SenderUserId)
	public static List<UserFriendRequestData> GetDataListBySenderUserId(long senderUserId)
	{
		return dataTable.GetDataList("SenderUserId", (object)senderUserId);
	}
	#endregion
	#region DataTableIndex (TargetUserId)
	public static List<UserFriendRequestData> GetDataListByTargetUserId(long targetUserId)
	{
		return dataTable.GetDataList("TargetUserId", (object)targetUserId);
	}
	#endregion
}

