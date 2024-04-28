using System.Collections.Generic;

public partial class ShopItemData : IUnique<long>
{
	#region NullObject
	public static ShopItemData Null => NullObjectContainer.Get<ShopItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ShopItemData> dataTable {
		get {
			DataTable<long, ShopItemData> result;
			if (GameDb.TableExists<long, ShopItemData>()) {
				result = GameDb.From<long, ShopItemData>();
			} else {
				result = GameDb.CreateTable<long, ShopItemData>();
				SetupShopItemDataTableIndexGenerated(result);
				SetupShopItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ShopItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ShopItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ShopItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ShopItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupShopItemDataTableIndex(DataTable<long, ShopItemData> targetDataTable);

	private static void SetupShopItemDataTableIndexGenerated(DataTable<long, ShopItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateUniqueIndex("PlatformProductId", aData => (object)aData.platformProductId);
		targetDataTable.CreateIndex("ShopId", aData => (object)aData.shopId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ShopItemData GetDataById(long id)
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
	#region DataTableUniqueIndex(PlatformProductId)
	public static ShopItemData GetDataByPlatformProductId(string platformProductId)
	{
		return dataTable.GetData("PlatformProductId", (object)platformProductId);
	}

	public static void RemoveDataByPlatformProductIds(ICollection<string> platformProductIds)
	{
		platformProductIds.ForEach(aPlatformProductId => RemoveDataByPlatformProductId(aPlatformProductId));
	}

	public static void RemoveDataByPlatformProductId(string platformProductId)
	{
		dataTable.DeleteByKey("PlatformProductId", (object)platformProductId);
	}
	#endregion
	#region DataTableIndex (ShopId)
	public static List<ShopItemData> GetDataListByShopId(long shopId)
	{
		return dataTable.GetDataList("ShopId", (object)shopId);
	}
	#endregion
}

