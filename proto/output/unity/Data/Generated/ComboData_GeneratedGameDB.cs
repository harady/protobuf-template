using System.Collections.Generic;

public partial class ComboData : IUnique<long>
{
	#region NullObject
	public static ComboData Null => NullObjectContainer.Get<ComboData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ComboData> dataTable {
		get {
			DataTable<long, ComboData> result;
			if (GameDb.TableExists<long, ComboData>()) {
				result = GameDb.From<long, ComboData>();
			} else {
				result = GameDb.CreateTable<long, ComboData>();
				SetupComboDataTableIndexGenerated(result);
				SetupComboDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ComboData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ComboData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ComboData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ComboData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupComboDataTableIndex(DataTable<long, ComboData> targetDataTable);

	private static void SetupComboDataTableIndexGenerated(DataTable<long, ComboData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ComboData GetDataById(long id)
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

