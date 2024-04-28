using System.Collections.Generic;

public partial class DailyEventTableItemData : IUnique<long>
{
	#region NullObject
	public static DailyEventTableItemData Null => NullObjectContainer.Get<DailyEventTableItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, DailyEventTableItemData> dataTable {
		get {
			DataTable<long, DailyEventTableItemData> result;
			if (GameDb.TableExists<long, DailyEventTableItemData>()) {
				result = GameDb.From<long, DailyEventTableItemData>();
			} else {
				result = GameDb.CreateTable<long, DailyEventTableItemData>();
				SetupDailyEventTableItemDataTableIndexGenerated(result);
				SetupDailyEventTableItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<DailyEventTableItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(DailyEventTableItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<DailyEventTableItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<DailyEventTableItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupDailyEventTableItemDataTableIndex(DataTable<long, DailyEventTableItemData> targetDataTable);

	private static void SetupDailyEventTableItemDataTableIndexGenerated(DataTable<long, DailyEventTableItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("DailyEventTableId", aData => (object)aData.dailyEventTableId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static DailyEventTableItemData GetDataById(long id)
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
	#region DataTableIndex (DailyEventTableId)
	public static List<DailyEventTableItemData> GetDataListByDailyEventTableId(long dailyEventTableId)
	{
		return dataTable.GetDataList("DailyEventTableId", (object)dailyEventTableId);
	}
	#endregion
}

