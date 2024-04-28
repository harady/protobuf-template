using System.Collections.Generic;

public partial class UserUnitData : IUnique<long>
{
	#region NullObject
	public static UserUnitData Null => NullObjectContainer.Get<UserUnitData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserUnitData> dataTable {
		get {
			DataTable<long, UserUnitData> result;
			if (GameDb.TableExists<long, UserUnitData>()) {
				result = GameDb.From<long, UserUnitData>();
			} else {
				result = GameDb.CreateTable<long, UserUnitData>();
				SetupUserUnitDataTableIndexGenerated(result);
				SetupUserUnitDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserUnitData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserUnitData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserUnitData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserUnitData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserUnitDataTableIndex(DataTable<long, UserUnitData> targetDataTable);

	private static void SetupUserUnitDataTableIndexGenerated(DataTable<long, UserUnitData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
		targetDataTable.CreateIndex("UnitId", aData => (object)aData.unitId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserUnitData GetDataById(long id)
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
	public static List<UserUnitData> GetDataListByUserId(long userId)
	{
		return dataTable.GetDataList("UserId", (object)userId);
	}
	#endregion
	#region DataTableIndex (UnitId)
	public static List<UserUnitData> GetDataListByUnitId(long unitId)
	{
		return dataTable.GetDataList("UnitId", (object)unitId);
	}
	#endregion
}

