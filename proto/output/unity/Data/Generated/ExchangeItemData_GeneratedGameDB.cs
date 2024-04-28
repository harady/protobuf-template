using System.Collections.Generic;

public partial class ExchangeItemData : IUnique<long>
{
	#region NullObject
	public static ExchangeItemData Null => NullObjectContainer.Get<ExchangeItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ExchangeItemData> dataTable {
		get {
			DataTable<long, ExchangeItemData> result;
			if (GameDb.TableExists<long, ExchangeItemData>()) {
				result = GameDb.From<long, ExchangeItemData>();
			} else {
				result = GameDb.CreateTable<long, ExchangeItemData>();
				SetupExchangeItemDataTableIndexGenerated(result);
				SetupExchangeItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ExchangeItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ExchangeItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ExchangeItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ExchangeItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupExchangeItemDataTableIndex(DataTable<long, ExchangeItemData> targetDataTable);

	private static void SetupExchangeItemDataTableIndexGenerated(DataTable<long, ExchangeItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("ExchangeId", aData => (object)aData.exchangeId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ExchangeItemData GetDataById(long id)
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
	#region DataTableIndex (ExchangeId)
	public static List<ExchangeItemData> GetDataListByExchangeId(long exchangeId)
	{
		return dataTable.GetDataList("ExchangeId", (object)exchangeId);
	}
	#endregion
}

