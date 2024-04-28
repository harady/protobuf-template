using System.Collections.Generic;

public partial class IdentifableItemData : IUnique<long>
{
	#region NullObject
	public static IdentifableItemData Null => NullObjectContainer.Get<IdentifableItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, IdentifableItemData> dataTable {
		get {
			DataTable<long, IdentifableItemData> result;
			if (GameDb.TableExists<long, IdentifableItemData>()) {
				result = GameDb.From<long, IdentifableItemData>();
			} else {
				result = GameDb.CreateTable<long, IdentifableItemData>();
				SetupIdentifableItemDataTableIndexGenerated(result);
				SetupIdentifableItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<IdentifableItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(IdentifableItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<IdentifableItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<IdentifableItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupIdentifableItemDataTableIndex(DataTable<long, IdentifableItemData> targetDataTable);

	private static void SetupIdentifableItemDataTableIndexGenerated(DataTable<long, IdentifableItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("Type", aData => (object)aData.type);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static IdentifableItemData GetDataById(long id)
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
	#region DataTableIndex (Type)
	public static List<IdentifableItemData> GetDataListByType(IdentifableItemType type)
	{
		return dataTable.GetDataList("Type", (object)type);
	}
	#endregion
}

