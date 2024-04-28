using System.Collections.Generic;

public partial class LoginBonusItemData : IUnique<long>
{
	#region NullObject
	public static LoginBonusItemData Null => NullObjectContainer.Get<LoginBonusItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, LoginBonusItemData> dataTable {
		get {
			DataTable<long, LoginBonusItemData> result;
			if (GameDb.TableExists<long, LoginBonusItemData>()) {
				result = GameDb.From<long, LoginBonusItemData>();
			} else {
				result = GameDb.CreateTable<long, LoginBonusItemData>();
				SetupLoginBonusItemDataTableIndexGenerated(result);
				SetupLoginBonusItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<LoginBonusItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(LoginBonusItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<LoginBonusItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<LoginBonusItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupLoginBonusItemDataTableIndex(DataTable<long, LoginBonusItemData> targetDataTable);

	private static void SetupLoginBonusItemDataTableIndexGenerated(DataTable<long, LoginBonusItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static LoginBonusItemData GetDataById(long id)
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

