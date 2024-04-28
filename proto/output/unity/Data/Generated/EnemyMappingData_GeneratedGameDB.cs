using System.Collections.Generic;

public partial class EnemyMappingData : IUnique<long>
{
	#region NullObject
	public static EnemyMappingData Null => NullObjectContainer.Get<EnemyMappingData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EnemyMappingData> dataTable {
		get {
			DataTable<long, EnemyMappingData> result;
			if (GameDb.TableExists<long, EnemyMappingData>()) {
				result = GameDb.From<long, EnemyMappingData>();
			} else {
				result = GameDb.CreateTable<long, EnemyMappingData>();
				SetupEnemyMappingDataTableIndexGenerated(result);
				SetupEnemyMappingDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EnemyMappingData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EnemyMappingData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EnemyMappingData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EnemyMappingData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEnemyMappingDataTableIndex(DataTable<long, EnemyMappingData> targetDataTable);

	private static void SetupEnemyMappingDataTableIndexGenerated(DataTable<long, EnemyMappingData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("RoundId", aData => (object)aData.roundId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EnemyMappingData GetDataById(long id)
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
	#region DataTableIndex (RoundId)
	public static List<EnemyMappingData> GetDataListByRoundId(long roundId)
	{
		return dataTable.GetDataList("RoundId", (object)roundId);
	}
	#endregion
}

