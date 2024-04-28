using System.Collections.Generic;

public partial class UserPurchaseData : IUnique<long>
{
	#region NullObject
	public static UserPurchaseData Null => NullObjectContainer.Get<UserPurchaseData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserPurchaseData> dataTable {
		get {
			DataTable<long, UserPurchaseData> result;
			if (GameDb.TableExists<long, UserPurchaseData>()) {
				result = GameDb.From<long, UserPurchaseData>();
			} else {
				result = GameDb.CreateTable<long, UserPurchaseData>();
				SetupUserPurchaseDataTableIndexGenerated(result);
				SetupUserPurchaseDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserPurchaseData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserPurchaseData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserPurchaseData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserPurchaseData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserPurchaseDataTableIndex(DataTable<long, UserPurchaseData> targetDataTable);

	private static void SetupUserPurchaseDataTableIndexGenerated(DataTable<long, UserPurchaseData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserPurchaseData GetDataById(long id)
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
	public static List<UserPurchaseData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
}

