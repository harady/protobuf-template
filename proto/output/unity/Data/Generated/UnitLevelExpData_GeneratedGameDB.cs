using System.Collections.Generic;

public partial class UnitLevelExpData : IUnique<long>
{
	#region NullObject
	public static UnitLevelExpData Null => NullObjectContainer.Get<UnitLevelExpData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UnitLevelExpData> dataTable {
		get {
			DataTable<long, UnitLevelExpData> result;
			if (GameDb.TableExists<long, UnitLevelExpData>()) {
				result = GameDb.From<long, UnitLevelExpData>();
			} else {
				result = GameDb.CreateTable<long, UnitLevelExpData>();
				SetupUnitLevelExpDataTableIndexGenerated(result);
				SetupUnitLevelExpDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UnitLevelExpData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UnitLevelExpData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UnitLevelExpData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UnitLevelExpData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUnitLevelExpDataTableIndex(DataTable<long, UnitLevelExpData> targetDataTable);

	private static void SetupUnitLevelExpDataTableIndexGenerated(DataTable<long, UnitLevelExpData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("GrowthType", aData => (object)aData.growthType);
		targetDataTable.CreateIndex("Level", aData => (object)aData.level);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UnitLevelExpData GetDataById(long id)
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
	#region DataTableIndex (GrowthType)
	public static List<UnitLevelExpData> GetDataListByGrowthType(long growthType)
	{
		return dataTable.GetDataList("GrowthType", (object)growthType);
	}
	#endregion
	#region DataTableIndex (Level)
	public static List<UnitLevelExpData> GetDataListByLevel(long level)
	{
		return dataTable.GetDataList("Level", (object)level);
	}
	#endregion
}

