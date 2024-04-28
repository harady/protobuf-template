using System.Collections.Generic;

public partial class ShopScheduleData : IUnique<long>
{
	#region NullObject
	public static ShopScheduleData Null => NullObjectContainer.Get<ShopScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ShopScheduleData> dataTable {
		get {
			DataTable<long, ShopScheduleData> result;
			if (GameDb.TableExists<long, ShopScheduleData>()) {
				result = GameDb.From<long, ShopScheduleData>();
			} else {
				result = GameDb.CreateTable<long, ShopScheduleData>();
				SetupShopScheduleDataTableIndexGenerated(result);
				SetupShopScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ShopScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ShopScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ShopScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ShopScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupShopScheduleDataTableIndex(DataTable<long, ShopScheduleData> targetDataTable);

	private static void SetupShopScheduleDataTableIndexGenerated(DataTable<long, ShopScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("ShopId", aData => (object)aData.shopId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ShopScheduleData GetDataById(long id)
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
	#region DataTableIndex (ShopId)
	public static List<ShopScheduleData> GetDataListByShopId(long shopId)
	{
		return dataTable.GetDataList("ShopId", (object)shopId);
	}
	#endregion
}

