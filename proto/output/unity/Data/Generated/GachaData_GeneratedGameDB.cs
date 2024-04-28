using System.Collections.Generic;

public partial class GachaData : IUnique<long>
{
	#region NullObject
	public static GachaData Null => NullObjectContainer.Get<GachaData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaData> dataTable {
		get {
			DataTable<long, GachaData> result;
			if (GameDb.TableExists<long, GachaData>()) {
				result = GameDb.From<long, GachaData>();
			} else {
				result = GameDb.CreateTable<long, GachaData>();
				SetupGachaDataTableIndexGenerated(result);
				SetupGachaDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaDataTableIndex(DataTable<long, GachaData> targetDataTable);

	private static void SetupGachaDataTableIndexGenerated(DataTable<long, GachaData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static GachaData GetDataById(long id)
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

