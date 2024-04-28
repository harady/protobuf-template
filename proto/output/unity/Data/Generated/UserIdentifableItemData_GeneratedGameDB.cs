using System.Collections.Generic;

public partial class UserIdentifableItemData : IUnique<long>
{
	#region NullObject
	public static UserIdentifableItemData Null => NullObjectContainer.Get<UserIdentifableItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserIdentifableItemData> dataTable {
		get {
			DataTable<long, UserIdentifableItemData> result;
			if (GameDb.TableExists<long, UserIdentifableItemData>()) {
				result = GameDb.From<long, UserIdentifableItemData>();
			} else {
				result = GameDb.CreateTable<long, UserIdentifableItemData>();
				SetupUserIdentifableItemDataTableIndexGenerated(result);
				SetupUserIdentifableItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserIdentifableItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserIdentifableItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserIdentifableItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserIdentifableItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserIdentifableItemDataTableIndex(DataTable<long, UserIdentifableItemData> targetDataTable);

	private static void SetupUserIdentifableItemDataTableIndexGenerated(DataTable<long, UserIdentifableItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserIdentifableItemData GetDataById(long id)
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
	public static List<UserIdentifableItemData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
}

