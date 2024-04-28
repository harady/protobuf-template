using System.Collections.Generic;

public partial class EventQuestCategoryData : IUnique<long>
{
	#region NullObject
	public static EventQuestCategoryData Null => NullObjectContainer.Get<EventQuestCategoryData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EventQuestCategoryData> dataTable {
		get {
			DataTable<long, EventQuestCategoryData> result;
			if (GameDb.TableExists<long, EventQuestCategoryData>()) {
				result = GameDb.From<long, EventQuestCategoryData>();
			} else {
				result = GameDb.CreateTable<long, EventQuestCategoryData>();
				SetupEventQuestCategoryDataTableIndexGenerated(result);
				SetupEventQuestCategoryDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EventQuestCategoryData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EventQuestCategoryData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EventQuestCategoryData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EventQuestCategoryData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEventQuestCategoryDataTableIndex(DataTable<long, EventQuestCategoryData> targetDataTable);

	private static void SetupEventQuestCategoryDataTableIndexGenerated(DataTable<long, EventQuestCategoryData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EventQuestCategoryData GetDataById(long id)
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

