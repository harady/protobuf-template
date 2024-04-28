using System.Collections.Generic;

public partial class UnitCategoryData : IUnique<long>
{
	#region NullObject
	public static UnitCategoryData Null => NullObjectContainer.Get<UnitCategoryData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UnitCategoryData> dataTable {
		get {
			DataTable<long, UnitCategoryData> result;
			if (GameDb.TableExists<long, UnitCategoryData>()) {
				result = GameDb.From<long, UnitCategoryData>();
			} else {
				result = GameDb.CreateTable<long, UnitCategoryData>();
				SetupUnitCategoryDataTableIndexGenerated(result);
				SetupUnitCategoryDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UnitCategoryData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UnitCategoryData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UnitCategoryData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UnitCategoryData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUnitCategoryDataTableIndex(DataTable<long, UnitCategoryData> targetDataTable);

	private static void SetupUnitCategoryDataTableIndexGenerated(DataTable<long, UnitCategoryData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UnitCategoryData GetDataById(long id)
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

