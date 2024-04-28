using System.Collections.Generic;

public partial class ExchangeScheduleData : IUnique<long>
{
	#region NullObject
	public static ExchangeScheduleData Null => NullObjectContainer.Get<ExchangeScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ExchangeScheduleData> dataTable {
		get {
			DataTable<long, ExchangeScheduleData> result;
			if (GameDb.TableExists<long, ExchangeScheduleData>()) {
				result = GameDb.From<long, ExchangeScheduleData>();
			} else {
				result = GameDb.CreateTable<long, ExchangeScheduleData>();
				SetupExchangeScheduleDataTableIndexGenerated(result);
				SetupExchangeScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ExchangeScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ExchangeScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ExchangeScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ExchangeScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupExchangeScheduleDataTableIndex(DataTable<long, ExchangeScheduleData> targetDataTable);

	private static void SetupExchangeScheduleDataTableIndexGenerated(DataTable<long, ExchangeScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("ExchangeId", aData => (object)aData.exchangeId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ExchangeScheduleData GetDataById(long id)
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
	public static List<ExchangeScheduleData> GetDataListByExchangeId(long exchangeId)
	{
		return dataTable.GetDataList("ExchangeId", (object)exchangeId);
	}
	#endregion
}

