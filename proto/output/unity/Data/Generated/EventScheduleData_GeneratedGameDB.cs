using System.Collections.Generic;

public partial class EventScheduleData : IUnique<long>
{
	#region NullObject
	public static EventScheduleData Null => NullObjectContainer.Get<EventScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EventScheduleData> dataTable {
		get {
			DataTable<long, EventScheduleData> result;
			if (GameDb.TableExists<long, EventScheduleData>()) {
				result = GameDb.From<long, EventScheduleData>();
			} else {
				result = GameDb.CreateTable<long, EventScheduleData>();
				SetupEventScheduleDataTableIndexGenerated(result);
				SetupEventScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EventScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EventScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EventScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EventScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEventScheduleDataTableIndex(DataTable<long, EventScheduleData> targetDataTable);

	private static void SetupEventScheduleDataTableIndexGenerated(DataTable<long, EventScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("QuestId", aData => (object)aData.questId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EventScheduleData GetDataById(long id)
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
	#region DataTableIndex (QuestId)
	public static List<EventScheduleData> GetDataListByQuestId(long questId)
	{
		return dataTable.GetDataList("QuestId", (object)questId);
	}
	#endregion
}

