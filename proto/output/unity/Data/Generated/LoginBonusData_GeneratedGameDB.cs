using System.Collections.Generic;

public partial class LoginBonusData : IUnique<long>
{
	#region NullObject
	public static LoginBonusData Null => NullObjectContainer.Get<LoginBonusData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, LoginBonusData> dataTable {
		get {
			DataTable<long, LoginBonusData> result;
			if (GameDb.TableExists<long, LoginBonusData>()) {
				result = GameDb.From<long, LoginBonusData>();
			} else {
				result = GameDb.CreateTable<long, LoginBonusData>();
				SetupLoginBonusDataTableIndexGenerated(result);
				SetupLoginBonusDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<LoginBonusData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(LoginBonusData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<LoginBonusData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<LoginBonusData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupLoginBonusDataTableIndex(DataTable<long, LoginBonusData> targetDataTable);

	private static void SetupLoginBonusDataTableIndexGenerated(DataTable<long, LoginBonusData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static LoginBonusData GetDataById(long id)
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

