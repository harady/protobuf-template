using System.Collections.Generic;

public partial class GachaButtonData : IUnique<long>
{
	#region NullObject
	public static GachaButtonData Null => NullObjectContainer.Get<GachaButtonData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaButtonData> dataTable {
		get {
			DataTable<long, GachaButtonData> result;
			if (GameDb.TableExists<long, GachaButtonData>()) {
				result = GameDb.From<long, GachaButtonData>();
			} else {
				result = GameDb.CreateTable<long, GachaButtonData>();
				SetupGachaButtonDataTableIndexGenerated(result);
				SetupGachaButtonDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaButtonData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaButtonData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaButtonData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaButtonData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaButtonDataTableIndex(DataTable<long, GachaButtonData> targetDataTable);

	private static void SetupGachaButtonDataTableIndexGenerated(DataTable<long, GachaButtonData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("GachaId", aData => (object)aData.gachaId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static GachaButtonData GetDataById(long id)
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
	public static List<GachaButtonData> GetDataListByGachaId(long gachaId)
	{
		return dataTable.GetDataList("GachaId", (object)gachaId);
	}
	#endregion
}

