using System.Collections.Generic;

public partial class MissionGroupData : IUnique<long>
{
	#region NullObject
	public static MissionGroupData Null => NullObjectContainer.Get<MissionGroupData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, MissionGroupData> dataTable {
		get {
			DataTable<long, MissionGroupData> result;
			if (GameDb.TableExists<long, MissionGroupData>()) {
				result = GameDb.From<long, MissionGroupData>();
			} else {
				result = GameDb.CreateTable<long, MissionGroupData>();
				SetupMissionGroupDataTableIndexGenerated(result);
				SetupMissionGroupDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<MissionGroupData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(MissionGroupData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<MissionGroupData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<MissionGroupData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupMissionGroupDataTableIndex(DataTable<long, MissionGroupData> targetDataTable);

	private static void SetupMissionGroupDataTableIndexGenerated(DataTable<long, MissionGroupData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("Type", aData => (object)aData.type);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static MissionGroupData GetDataById(long id)
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
	public static List<MissionGroupData> GetDataListByType(MissionGroupType type)
	{
		return dataTable.GetDataList("Type", (object)type);
	}
	#endregion
}

