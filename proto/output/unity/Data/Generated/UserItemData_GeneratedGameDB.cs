using System.Collections.Generic;

public partial class UserItemData : IUnique<long>
{
	#region NullObject
	public static UserItemData Null => NullObjectContainer.Get<UserItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserItemData> dataTable {
		get {
			DataTable<long, UserItemData> result;
			if (GameDb.TableExists<long, UserItemData>()) {
				result = GameDb.From<long, UserItemData>();
			} else {
				result = GameDb.CreateTable<long, UserItemData>();
				SetupUserItemDataTableIndexGenerated(result);
				SetupUserItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserItemDataTableIndex(DataTable<long, UserItemData> targetDataTable);

	private static void SetupUserItemDataTableIndexGenerated(DataTable<long, UserItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateUniqueIndex("ItemId", aData => (object)aData.itemId);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserItemData GetDataById(long id)
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
	#region DataTableUniqueIndex(ItemId)
	public static UserItemData GetDataByItemId(long itemId)
	{
		return dataTable.GetData("ItemId", (object)itemId);
	}

	public static void RemoveDataByItemIds(ICollection<long> itemIds)
	{
		itemIds.ForEach(aItemId => RemoveDataByItemId(aItemId));
	}

	public static void RemoveDataByItemId(long itemId)
	{
		dataTable.DeleteByKey("ItemId", (object)itemId);
	}
	#endregion
	#region DataTableIndex (UserId)
	public static List<UserItemData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
}

