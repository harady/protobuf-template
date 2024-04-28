using System.Collections.Generic;

public partial class UserMessageData : IUnique<long>
{
	#region NullObject
	public static UserMessageData Null => NullObjectContainer.Get<UserMessageData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserMessageData> dataTable {
		get {
			DataTable<long, UserMessageData> result;
			if (GameDb.TableExists<long, UserMessageData>()) {
				result = GameDb.From<long, UserMessageData>();
			} else {
				result = GameDb.CreateTable<long, UserMessageData>();
				SetupUserMessageDataTableIndexGenerated(result);
				SetupUserMessageDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserMessageData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserMessageData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserMessageData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserMessageData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserMessageDataTableIndex(DataTable<long, UserMessageData> targetDataTable);

	private static void SetupUserMessageDataTableIndexGenerated(DataTable<long, UserMessageData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserMessageData GetDataById(long id)
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
	public static List<UserMessageData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
}

