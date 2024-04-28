using System.Collections.Generic;

public partial class LogData : IUnique<long>
{
	#region NullObject
	public static LogData Null => NullObjectContainer.Get<LogData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, LogData> dataTable {
		get {
			DataTable<long, LogData> result;
			if (GameDb.TableExists<long, LogData>()) {
				result = GameDb.From<long, LogData>();
			} else {
				result = GameDb.CreateTable<long, LogData>();
				SetupLogDataTableIndexGenerated(result);
				SetupLogDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<LogData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(LogData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<LogData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<LogData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupLogDataTableIndex(DataTable<long, LogData> targetDataTable);

	private static void SetupLogDataTableIndexGenerated(DataTable<long, LogData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static LogData GetDataById(long id)
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

