using System.Collections.Generic;

public partial class ItemData : IUnique<long>
{
	#region NullObject
	public static ItemData Null => NullObjectContainer.Get<ItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ItemData> dataTable {
		get {
			DataTable<long, ItemData> result;
			if (GameDb.TableExists<long, ItemData>()) {
				result = GameDb.From<long, ItemData>();
			} else {
				result = GameDb.CreateTable<long, ItemData>();
				SetupItemDataTableIndexGenerated(result);
				SetupItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupItemDataTableIndex(DataTable<long, ItemData> targetDataTable);

	private static void SetupItemDataTableIndexGenerated(DataTable<long, ItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("Category", aData => (object)aData.category);
		targetDataTable.CreateIndex("Type", aData => (object)aData.type);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ItemData GetDataById(long id)
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
	#region DataTableIndex (Category)
	public static List<ItemData> GetDataListByCategory(ItemCategory category)
	{
		return dataTable.GetDataList("Category", (object)category);
	}
	#endregion
	#region DataTableIndex (Type)
	public static List<ItemData> GetDataListByType(ItemType type)
	{
		return dataTable.GetDataList("Type", (object)type);
	}
	#endregion
}

