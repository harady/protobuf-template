using System.Collections.Generic;

public partial class UserDeckData : IUnique<long>
{
	#region NullObject
	public static UserDeckData Null => NullObjectContainer.Get<UserDeckData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserDeckData> dataTable {
		get {
			DataTable<long, UserDeckData> result;
			if (GameDb.TableExists<long, UserDeckData>()) {
				result = GameDb.From<long, UserDeckData>();
			} else {
				result = GameDb.CreateTable<long, UserDeckData>();
				SetupUserDeckDataTableIndexGenerated(result);
				SetupUserDeckDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserDeckData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserDeckData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserDeckData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserDeckData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserDeckDataTableIndex(DataTable<long, UserDeckData> targetDataTable);

	private static void SetupUserDeckDataTableIndexGenerated(DataTable<long, UserDeckData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
		targetDataTable.CreateIndex("DeckNo", aData => (object)aData.deckNo);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserDeckData GetDataById(long id)
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
	public static List<UserDeckData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
	#region DataTableIndex (DeckNo)
	public static List<UserDeckData> GetDataListByDeckNo(long deckNo)
	{
		return dataTable.GetDataList("DeckNo", (object)deckNo);
	}
	#endregion
}

