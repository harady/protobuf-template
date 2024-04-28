using System.Collections.Generic;

public partial class AbilityData : IUnique<long>
{
	#region NullObject
	public static AbilityData Null => NullObjectContainer.Get<AbilityData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, AbilityData> dataTable {
		get {
			DataTable<long, AbilityData> result;
			if (GameDb.TableExists<long, AbilityData>()) {
				result = GameDb.From<long, AbilityData>();
			} else {
				result = GameDb.CreateTable<long, AbilityData>();
				SetupAbilityDataTableIndexGenerated(result);
				SetupAbilityDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<AbilityData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(AbilityData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<AbilityData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<AbilityData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupAbilityDataTableIndex(DataTable<long, AbilityData> targetDataTable);

	private static void SetupAbilityDataTableIndexGenerated(DataTable<long, AbilityData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static AbilityData GetDataById(long id)
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

