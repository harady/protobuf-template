using System.Collections.Generic;

public partial class GachaPoolItemData : IUnique<long>
{
	#region NullObject
	public static GachaPoolItemData Null => NullObjectContainer.Get<GachaPoolItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaPoolItemData> dataTable {
		get {
			DataTable<long, GachaPoolItemData> result;
			if (GameDb.TableExists<long, GachaPoolItemData>()) {
				result = GameDb.From<long, GachaPoolItemData>();
			} else {
				result = GameDb.CreateTable<long, GachaPoolItemData>();
				SetupGachaPoolItemDataTableIndexGenerated(result);
				SetupGachaPoolItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaPoolItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaPoolItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaPoolItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaPoolItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaPoolItemDataTableIndex(DataTable<long, GachaPoolItemData> targetDataTable);

	private static void SetupGachaPoolItemDataTableIndexGenerated(DataTable<long, GachaPoolItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("GachaPoolId", aData => (object)aData.gachaPoolId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static GachaPoolItemData GetDataById(long id)
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
	#region DataTableIndex (GachaPoolId)
	public static List<GachaPoolItemData> GetDataListByGachaPoolId(long gachaPoolId)
	{
		return dataTable.GetDataList("GachaPoolId", (object)gachaPoolId);
	}
	#endregion
}

