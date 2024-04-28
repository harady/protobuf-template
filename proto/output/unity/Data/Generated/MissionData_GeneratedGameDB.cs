using System.Collections.Generic;

public partial class MissionData : IUnique<long>
{
	#region NullObject
	public static MissionData Null => NullObjectContainer.Get<MissionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, MissionData> dataTable {
		get {
			DataTable<long, MissionData> result;
			if (GameDb.TableExists<long, MissionData>()) {
				result = GameDb.From<long, MissionData>();
			} else {
				result = GameDb.CreateTable<long, MissionData>();
				SetupMissionDataTableIndexGenerated(result);
				SetupMissionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<MissionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(MissionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<MissionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<MissionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupMissionDataTableIndex(DataTable<long, MissionData> targetDataTable);

	private static void SetupMissionDataTableIndexGenerated(DataTable<long, MissionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("Type", aData => (object)aData.type);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static MissionData GetDataById(long id)
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
	#region DataTableIndex (Type)
	public static List<MissionData> GetDataListByType(MissionType type)
	{
		return dataTable.GetDataList("Type", (object)type);
	}
	#endregion
}

