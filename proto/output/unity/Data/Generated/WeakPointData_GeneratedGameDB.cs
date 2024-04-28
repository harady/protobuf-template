using System.Collections.Generic;

public partial class WeakPointData : IUnique<long>
{
	#region NullObject
	public static WeakPointData Null => NullObjectContainer.Get<WeakPointData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, WeakPointData> dataTable {
		get {
			DataTable<long, WeakPointData> result;
			if (GameDb.TableExists<long, WeakPointData>()) {
				result = GameDb.From<long, WeakPointData>();
			} else {
				result = GameDb.CreateTable<long, WeakPointData>();
				SetupWeakPointDataTableIndexGenerated(result);
				SetupWeakPointDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<WeakPointData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(WeakPointData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<WeakPointData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<WeakPointData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupWeakPointDataTableIndex(DataTable<long, WeakPointData> targetDataTable);

	private static void SetupWeakPointDataTableIndexGenerated(DataTable<long, WeakPointData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static WeakPointData GetDataById(long id)
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

