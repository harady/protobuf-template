using System.Collections.Generic;

public partial class UserShopItemData : IUnique<long>
{
	#region NullObject
	public static UserShopItemData Null => NullObjectContainer.Get<UserShopItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserShopItemData> dataTable {
		get {
			DataTable<long, UserShopItemData> result;
			if (GameDb.TableExists<long, UserShopItemData>()) {
				result = GameDb.From<long, UserShopItemData>();
			} else {
				result = GameDb.CreateTable<long, UserShopItemData>();
				SetupUserShopItemDataTableIndexGenerated(result);
				SetupUserShopItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserShopItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserShopItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserShopItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserShopItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserShopItemDataTableIndex(DataTable<long, UserShopItemData> targetDataTable);

	private static void SetupUserShopItemDataTableIndexGenerated(DataTable<long, UserShopItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
		targetDataTable.CreateIndex("ShopItemId", aData => (object)aData.shopItemId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserShopItemData GetDataById(long id)
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
	public static List<UserShopItemData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
	#region DataTableIndex (ShopItemId)
	public static List<UserShopItemData> GetDataListByShopItemId(long shopItemId)
	{
		return dataTable.GetDataList("ShopItemId", (object)shopItemId);
	}
	#endregion
}

