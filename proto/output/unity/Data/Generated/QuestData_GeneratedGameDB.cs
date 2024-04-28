using System.Collections.Generic;

public partial class QuestData : IUnique<long>
{
	#region NullObject
	public static QuestData Null => NullObjectContainer.Get<QuestData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, QuestData> dataTable {
		get {
			DataTable<long, QuestData> result;
			if (GameDb.TableExists<long, QuestData>()) {
				result = GameDb.From<long, QuestData>();
			} else {
				result = GameDb.CreateTable<long, QuestData>();
				SetupQuestDataTableIndexGenerated(result);
				SetupQuestDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<QuestData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(QuestData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<QuestData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<QuestData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupQuestDataTableIndex(DataTable<long, QuestData> targetDataTable);

	private static void SetupQuestDataTableIndexGenerated(DataTable<long, QuestData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("QuestGroupId", aData => (object)aData.questGroupId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static QuestData GetDataById(long id)
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
	#region DataTableIndex (QuestGroupId)
	public static List<QuestData> GetDataListByQuestGroupId(long questGroupId)
	{
		return dataTable.GetDataList("QuestGroupId", (object)questGroupId);
	}
	#endregion
}

