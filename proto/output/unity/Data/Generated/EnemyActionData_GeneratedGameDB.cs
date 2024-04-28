using System.Collections.Generic;

public partial class EnemyActionData : IUnique<long>
{
	#region NullObject
	public static EnemyActionData Null => NullObjectContainer.Get<EnemyActionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EnemyActionData> dataTable {
		get {
			DataTable<long, EnemyActionData> result;
			if (GameDb.TableExists<long, EnemyActionData>()) {
				result = GameDb.From<long, EnemyActionData>();
			} else {
				result = GameDb.CreateTable<long, EnemyActionData>();
				SetupEnemyActionDataTableIndexGenerated(result);
				SetupEnemyActionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EnemyActionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EnemyActionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EnemyActionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EnemyActionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEnemyActionDataTableIndex(DataTable<long, EnemyActionData> targetDataTable);

	private static void SetupEnemyActionDataTableIndexGenerated(DataTable<long, EnemyActionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("EnemyId", aData => (object)aData.enemyId);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EnemyActionData GetDataById(long id)
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
	#region DataTableIndex (EnemyId)
	public static List<EnemyActionData> GetDataListByEnemyId(long enemyId)
	{
		return dataTable.GetDataList("EnemyId", (object)enemyId);
	}
	#endregion
}

