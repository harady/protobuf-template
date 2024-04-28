using System.Collections.Generic;

public partial class BattleInitEnemyData : IUnique<long>
{
	#region NullObject
	public static BattleInitEnemyData Null => NullObjectContainer.Get<BattleInitEnemyData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, BattleInitEnemyData> dataTable {
		get {
			DataTable<long, BattleInitEnemyData> result;
			if (GameDb.TableExists<long, BattleInitEnemyData>()) {
				result = GameDb.From<long, BattleInitEnemyData>();
			} else {
				result = GameDb.CreateTable<long, BattleInitEnemyData>();
				SetupBattleInitEnemyDataTableIndexGenerated(result);
				SetupBattleInitEnemyDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<BattleInitEnemyData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(BattleInitEnemyData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<BattleInitEnemyData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<BattleInitEnemyData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupBattleInitEnemyDataTableIndex(DataTable<long, BattleInitEnemyData> targetDataTable);

	private static void SetupBattleInitEnemyDataTableIndexGenerated(DataTable<long, BattleInitEnemyData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("RoundId", aData => (object)aData.roundId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static BattleInitEnemyData GetDataById(long id)
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
	public static List<BattleInitEnemyData> GetDataListByRoundId(long roundId)
	{
		return dataTable.GetDataList("RoundId", (object)roundId);
	}
	#endregion
}

