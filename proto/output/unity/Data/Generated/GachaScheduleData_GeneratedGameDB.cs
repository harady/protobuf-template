using System.Collections.Generic;

public partial class GachaScheduleData : IUnique<long>
{
	#region NullObject
	public static GachaScheduleData Null => NullObjectContainer.Get<GachaScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaScheduleData> dataTable {
		get {
			DataTable<long, GachaScheduleData> result;
			if (GameDb.TableExists<long, GachaScheduleData>()) {
				result = GameDb.From<long, GachaScheduleData>();
			} else {
				result = GameDb.CreateTable<long, GachaScheduleData>();
				SetupGachaScheduleDataTableIndexGenerated(result);
				SetupGachaScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaScheduleDataTableIndex(DataTable<long, GachaScheduleData> targetDataTable);

	private static void SetupGachaScheduleDataTableIndexGenerated(DataTable<long, GachaScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("GachaId", aData => (object)aData.gachaId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static GachaScheduleData GetDataById(long id)
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
	#region DataTableIndex (GachaId)
	public static List<GachaScheduleData> GetDataListByGachaId(long gachaId)
	{
		return dataTable.GetDataList("GachaId", (object)gachaId);
	}
	#endregion
}

