using System.Collections.Generic;

public partial class ResourceSetItemData : IUnique<long>
{
	#region NullObject
	public static ResourceSetItemData Null => NullObjectContainer.Get<ResourceSetItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ResourceSetItemData> dataTable {
		get {
			DataTable<long, ResourceSetItemData> result;
			if (GameDb.TableExists<long, ResourceSetItemData>()) {
				result = GameDb.From<long, ResourceSetItemData>();
			} else {
				result = GameDb.CreateTable<long, ResourceSetItemData>();
				SetupResourceSetItemDataTableIndexGenerated(result);
				SetupResourceSetItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ResourceSetItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ResourceSetItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ResourceSetItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ResourceSetItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupResourceSetItemDataTableIndex(DataTable<long, ResourceSetItemData> targetDataTable);

	private static void SetupResourceSetItemDataTableIndexGenerated(DataTable<long, ResourceSetItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("ResourceSetId", aData => (object)aData.resourceSetId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ResourceSetItemData GetDataById(long id)
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
	#region DataTableIndex (ResourceSetId)
	public static List<ResourceSetItemData> GetDataListByResourceSetId(long resourceSetId)
	{
		return dataTable.GetDataList("ResourceSetId", (object)resourceSetId);
	}
	#endregion
}

