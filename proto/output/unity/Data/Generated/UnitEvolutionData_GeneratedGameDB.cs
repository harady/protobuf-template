using System.Collections.Generic;

public partial class UnitEvolutionData : IUnique<long>
{
	#region NullObject
	public static UnitEvolutionData Null => NullObjectContainer.Get<UnitEvolutionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UnitEvolutionData> dataTable {
		get {
			DataTable<long, UnitEvolutionData> result;
			if (GameDb.TableExists<long, UnitEvolutionData>()) {
				result = GameDb.From<long, UnitEvolutionData>();
			} else {
				result = GameDb.CreateTable<long, UnitEvolutionData>();
				SetupUnitEvolutionDataTableIndexGenerated(result);
				SetupUnitEvolutionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UnitEvolutionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UnitEvolutionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UnitEvolutionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UnitEvolutionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUnitEvolutionDataTableIndex(DataTable<long, UnitEvolutionData> targetDataTable);

	private static void SetupUnitEvolutionDataTableIndexGenerated(DataTable<long, UnitEvolutionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("BaseUnitId", aData => (object)aData.baseUnitId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UnitEvolutionData GetDataById(long id)
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
	#region DataTableIndex (BaseUnitId)
	public static List<UnitEvolutionData> GetDataListByBaseUnitId(long baseUnitId)
	{
		return dataTable.GetDataList("BaseUnitId", (object)baseUnitId);
	}
	#endregion
}

