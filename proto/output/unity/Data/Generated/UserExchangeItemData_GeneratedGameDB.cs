using System.Collections.Generic;

public partial class UserExchangeItemData : IUnique<long>
{
	#region NullObject
	public static UserExchangeItemData Null => NullObjectContainer.Get<UserExchangeItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserExchangeItemData> dataTable {
		get {
			DataTable<long, UserExchangeItemData> result;
			if (GameDb.TableExists<long, UserExchangeItemData>()) {
				result = GameDb.From<long, UserExchangeItemData>();
			} else {
				result = GameDb.CreateTable<long, UserExchangeItemData>();
				SetupUserExchangeItemDataTableIndexGenerated(result);
				SetupUserExchangeItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserExchangeItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserExchangeItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserExchangeItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserExchangeItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserExchangeItemDataTableIndex(DataTable<long, UserExchangeItemData> targetDataTable);

	private static void SetupUserExchangeItemDataTableIndexGenerated(DataTable<long, UserExchangeItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
		targetDataTable.CreateIndex("ExchangeItemId", aData => (object)aData.exchangeItemId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserExchangeItemData GetDataById(long id)
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
	#region DataTableIndex (UserId)
	public static List<UserExchangeItemData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
	#region DataTableIndex (ExchangeItemId)
	public static List<UserExchangeItemData> GetDataListByExchangeItemId(long exchangeItemId)
	{
		return dataTable.GetDataList("ExchangeItemId", (object)exchangeItemId);
	}
	#endregion
}

