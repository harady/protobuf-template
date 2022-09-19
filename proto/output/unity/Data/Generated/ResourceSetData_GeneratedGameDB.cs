using System.Collections.Generic;


public partial class ResourceSetData : IUnique<long>
{
	#region NullObject
	public static ResourceSetData Null => NullObjectContainer.Get<ResourceSetData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ResourceSetData> dataTable {
		get {
			DataTable<long, ResourceSetData> result;
			if (GameDb.TableExists<long, ResourceSetData>()) {
				result = GameDb.From<long, ResourceSetData>();
			} else {
				result = GameDb.CreateTable<long, ResourceSetData>();
				SetupResourceSetDataTableIndexGenerated(result);
				SetupResourceSetDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ResourceSetData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ResourceSetData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ResourceSetData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ResourceSetData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupResourceSetDataTableIndex(DataTable<long, ResourceSetData> targetDataTable);

	private static void SetupResourceSetDataTableIndexGenerated(DataTable<long, ResourceSetData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Resourcesetdata", aData => (object)aData.resourcesetdata);
		targetDataTable.CreateIndex("Resourcesetdata", aData => (object)aData.resourcesetdata);
		targetDataTable.CreateIndex("Resourcesetdata", aData => (object)aData.resourcesetdata);
	}
	#endregion
}
