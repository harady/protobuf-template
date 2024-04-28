using System.Collections.Generic;

public partial class EventScheduleTermData : IUnique<long>
{
	#region NullObject
	public static EventScheduleTermData Null => NullObjectContainer.Get<EventScheduleTermData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EventScheduleTermData> dataTable {
		get {
			DataTable<long, EventScheduleTermData> result;
			if (GameDb.TableExists<long, EventScheduleTermData>()) {
				result = GameDb.From<long, EventScheduleTermData>();
			} else {
				result = GameDb.CreateTable<long, EventScheduleTermData>();
				SetupEventScheduleTermDataTableIndexGenerated(result);
				SetupEventScheduleTermDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EventScheduleTermData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EventScheduleTermData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EventScheduleTermData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EventScheduleTermData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEventScheduleTermDataTableIndex(DataTable<long, EventScheduleTermData> targetDataTable);

	private static void SetupEventScheduleTermDataTableIndexGenerated(DataTable<long, EventScheduleTermData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EventScheduleTermData GetDataById(long id)
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

