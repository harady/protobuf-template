using System.Collections.Generic;

public partial class UnitData : IUnique<long>
{
	#region NullObject
	public static UnitData Null => NullObjectContainer.Get<UnitData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UnitData> dataTable {
		get {
			DataTable<long, UnitData> result;
			if (GameDb.TableExists<long, UnitData>()) {
				result = GameDb.From<long, UnitData>();
			} else {
				result = GameDb.CreateTable<long, UnitData>();
				SetupUnitDataTableIndexGenerated(result);
				SetupUnitDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UnitData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UnitData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UnitData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UnitData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUnitDataTableIndex(DataTable<long, UnitData> targetDataTable);

	private static void SetupUnitDataTableIndexGenerated(DataTable<long, UnitData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("BaseUnitNumber", aData => (object)aData.baseUnitNumber);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UnitData GetDataById(long id)
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
	#region DataTableIndex (BaseUnitNumber)
	public static List<UnitData> GetDataListByBaseUnitNumber(long baseUnitNumber)
	{
		return dataTable.GetDataList("BaseUnitNumber", (object)baseUnitNumber);
	}
	#endregion
}

