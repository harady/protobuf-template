using System.Collections.Generic;

public partial class StageData : IUnique<long>
{
	#region NullObject
	public static StageData Null => NullObjectContainer.Get<StageData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, StageData> dataTable {
		get {
			DataTable<long, StageData> result;
			if (GameDb.TableExists<long, StageData>()) {
				result = GameDb.From<long, StageData>();
			} else {
				result = GameDb.CreateTable<long, StageData>();
				SetupStageDataTableIndexGenerated(result);
				SetupStageDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<StageData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(StageData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<StageData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<StageData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupStageDataTableIndex(DataTable<long, StageData> targetDataTable);

	private static void SetupStageDataTableIndexGenerated(DataTable<long, StageData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("QuestId", aData => (object)aData.questId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static StageData GetDataById(long id)
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
	public static List<StageData> GetDataListByQuestId(long questId)
	{
		return dataTable.GetDataList("QuestId", (object)questId);
	}
	#endregion
}

