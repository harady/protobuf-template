using System.Collections.Generic;

public partial class MissionScheduleData : IUnique<long>
{
	#region NullObject
	public static MissionScheduleData Null => NullObjectContainer.Get<MissionScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, MissionScheduleData> dataTable {
		get {
			DataTable<long, MissionScheduleData> result;
			if (GameDb.TableExists<long, MissionScheduleData>()) {
				result = GameDb.From<long, MissionScheduleData>();
			} else {
				result = GameDb.CreateTable<long, MissionScheduleData>();
				SetupMissionScheduleDataTableIndexGenerated(result);
				SetupMissionScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<MissionScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(MissionScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<MissionScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<MissionScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupMissionScheduleDataTableIndex(DataTable<long, MissionScheduleData> targetDataTable);

	private static void SetupMissionScheduleDataTableIndexGenerated(DataTable<long, MissionScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static MissionScheduleData GetDataById(long id)
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

