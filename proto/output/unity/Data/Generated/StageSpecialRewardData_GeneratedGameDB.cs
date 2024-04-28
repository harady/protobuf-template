using System.Collections.Generic;

public partial class StageSpecialRewardData : IUnique<long>
{
	#region NullObject
	public static StageSpecialRewardData Null => NullObjectContainer.Get<StageSpecialRewardData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, StageSpecialRewardData> dataTable {
		get {
			DataTable<long, StageSpecialRewardData> result;
			if (GameDb.TableExists<long, StageSpecialRewardData>()) {
				result = GameDb.From<long, StageSpecialRewardData>();
			} else {
				result = GameDb.CreateTable<long, StageSpecialRewardData>();
				SetupStageSpecialRewardDataTableIndexGenerated(result);
				SetupStageSpecialRewardDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<StageSpecialRewardData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(StageSpecialRewardData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<StageSpecialRewardData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<StageSpecialRewardData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupStageSpecialRewardDataTableIndex(DataTable<long, StageSpecialRewardData> targetDataTable);

	private static void SetupStageSpecialRewardDataTableIndexGenerated(DataTable<long, StageSpecialRewardData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("StageId", aData => (object)aData.stageId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static StageSpecialRewardData GetDataById(long id)
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
	#region DataTableIndex (StageId)
	public static List<StageSpecialRewardData> GetDataListByStageId(long stageId)
	{
		return dataTable.GetDataList("StageId", (object)stageId);
	}
	#endregion
}

