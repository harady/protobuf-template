using System.Collections.Generic;

public partial class DailyEventTableData : IUnique<long>
{
	#region NullObject
	public static DailyEventTableData Null => NullObjectContainer.Get<DailyEventTableData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, DailyEventTableData> dataTable {
		get {
			DataTable<long, DailyEventTableData> result;
			if (GameDb.TableExists<long, DailyEventTableData>()) {
				result = GameDb.From<long, DailyEventTableData>();
			} else {
				result = GameDb.CreateTable<long, DailyEventTableData>();
				SetupDailyEventTableDataTableIndexGenerated(result);
				SetupDailyEventTableDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<DailyEventTableData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(DailyEventTableData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<DailyEventTableData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<DailyEventTableData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupDailyEventTableDataTableIndex(DataTable<long, DailyEventTableData> targetDataTable);

	private static void SetupDailyEventTableDataTableIndexGenerated(DataTable<long, DailyEventTableData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static DailyEventTableData GetDataById(long id)
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

