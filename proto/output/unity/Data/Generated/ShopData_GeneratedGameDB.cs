using System.Collections.Generic;

public partial class ShopData : IUnique<long>
{
	#region NullObject
	public static ShopData Null => NullObjectContainer.Get<ShopData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ShopData> dataTable {
		get {
			DataTable<long, ShopData> result;
			if (GameDb.TableExists<long, ShopData>()) {
				result = GameDb.From<long, ShopData>();
			} else {
				result = GameDb.CreateTable<long, ShopData>();
				SetupShopDataTableIndexGenerated(result);
				SetupShopDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ShopData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ShopData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ShopData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ShopData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupShopDataTableIndex(DataTable<long, ShopData> targetDataTable);

	private static void SetupShopDataTableIndexGenerated(DataTable<long, ShopData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ShopData GetDataById(long id)
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
}

