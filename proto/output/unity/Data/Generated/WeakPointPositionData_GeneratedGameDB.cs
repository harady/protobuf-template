using System.Collections.Generic;

public partial class WeakPointPositionData : IUnique<long>
{
	#region NullObject
	public static WeakPointPositionData Null => NullObjectContainer.Get<WeakPointPositionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, WeakPointPositionData> dataTable {
		get {
			DataTable<long, WeakPointPositionData> result;
			if (GameDb.TableExists<long, WeakPointPositionData>()) {
				result = GameDb.From<long, WeakPointPositionData>();
			} else {
				result = GameDb.CreateTable<long, WeakPointPositionData>();
				SetupWeakPointPositionDataTableIndexGenerated(result);
				SetupWeakPointPositionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<WeakPointPositionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(WeakPointPositionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<WeakPointPositionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<WeakPointPositionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupWeakPointPositionDataTableIndex(DataTable<long, WeakPointPositionData> targetDataTable);

	private static void SetupWeakPointPositionDataTableIndexGenerated(DataTable<long, WeakPointPositionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("WeakPointId", aData => (object)aData.weakPointId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static WeakPointPositionData GetDataById(long id)
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
	#region DataTableIndex (WeakPointId)
	public static List<WeakPointPositionData> GetDataListByWeakPointId(long weakPointId)
	{
		return dataTable.GetDataList("WeakPointId", (object)weakPointId);
	}
	#endregion
}

