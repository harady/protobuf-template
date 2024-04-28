using System.Collections.Generic;

public partial class ConfigData : IUnique<long>
{
	#region NullObject
	public static ConfigData Null => NullObjectContainer.Get<ConfigData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ConfigData> dataTable {
		get {
			DataTable<long, ConfigData> result;
			if (GameDb.TableExists<long, ConfigData>()) {
				result = GameDb.From<long, ConfigData>();
			} else {
				result = GameDb.CreateTable<long, ConfigData>();
				SetupConfigDataTableIndexGenerated(result);
				SetupConfigDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ConfigData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ConfigData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ConfigData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ConfigData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupConfigDataTableIndex(DataTable<long, ConfigData> targetDataTable);

	private static void SetupConfigDataTableIndexGenerated(DataTable<long, ConfigData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateUniqueIndex("Key", aData => (object)aData.key);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ConfigData GetDataById(long id)
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
	#region DataTableUniqueIndex(Key)
	public static ConfigData GetDataByKey(string key)
	{
		return dataTable.GetData("Key", (object)key);
	}

	public static void RemoveDataByKeys(ICollection<string> keys)
	{
		keys.ForEach(aKey => RemoveDataByKey(aKey));
	}

	public static void RemoveDataByKey(string key)
	{
		dataTable.DeleteByKey("Key", (object)key);
	}
	#endregion
}

