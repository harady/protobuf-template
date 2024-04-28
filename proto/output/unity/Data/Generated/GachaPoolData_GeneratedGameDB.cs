using System.Collections.Generic;

public partial class GachaPoolData : IUnique<long>
{
	#region NullObject
	public static GachaPoolData Null => NullObjectContainer.Get<GachaPoolData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaPoolData> dataTable {
		get {
			DataTable<long, GachaPoolData> result;
			if (GameDb.TableExists<long, GachaPoolData>()) {
				result = GameDb.From<long, GachaPoolData>();
			} else {
				result = GameDb.CreateTable<long, GachaPoolData>();
				SetupGachaPoolDataTableIndexGenerated(result);
				SetupGachaPoolDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaPoolData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaPoolData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaPoolData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaPoolData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaPoolDataTableIndex(DataTable<long, GachaPoolData> targetDataTable);

	private static void SetupGachaPoolDataTableIndexGenerated(DataTable<long, GachaPoolData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("GachaId", aData => (object)aData.gachaId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static GachaPoolData GetDataById(long id)
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
	public static List<GachaPoolData> GetDataListByGachaId(long gachaId)
	{
		return dataTable.GetDataList("GachaId", (object)gachaId);
	}
	#endregion
}

