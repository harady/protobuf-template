using System.Collections.Generic;


public partial class UserBackupData : IUnique<long>
{
	#region NullObject
	public static UserBackupData Null => NullObjectContainer.Get<UserBackupData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserBackupData> dataTable {
		get {
			DataTable<long, UserBackupData> result;
			if (GameDb.TableExists<long, UserBackupData>()) {
				result = GameDb.From<long, UserBackupData>();
			} else {
				result = GameDb.CreateTable<long, UserBackupData>();
				SetupUserBackupDataTableIndexGenerated(result);
				SetupUserBackupDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserBackupData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserBackupData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserBackupData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserBackupData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserBackupDataTableIndex(DataTable<long, UserBackupData> targetDataTable);

	private static void SetupUserBackupDataTableIndexGenerated(DataTable<long, UserBackupData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserBackupData GetDataById(long id)
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
