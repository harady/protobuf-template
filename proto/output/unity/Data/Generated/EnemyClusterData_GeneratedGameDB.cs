using System.Collections.Generic;

public partial class EnemyClusterData : IUnique<long>
{
	#region NullObject
	public static EnemyClusterData Null => NullObjectContainer.Get<EnemyClusterData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EnemyClusterData> dataTable {
		get {
			DataTable<long, EnemyClusterData> result;
			if (GameDb.TableExists<long, EnemyClusterData>()) {
				result = GameDb.From<long, EnemyClusterData>();
			} else {
				result = GameDb.CreateTable<long, EnemyClusterData>();
				SetupEnemyClusterDataTableIndexGenerated(result);
				SetupEnemyClusterDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EnemyClusterData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EnemyClusterData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EnemyClusterData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EnemyClusterData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEnemyClusterDataTableIndex(DataTable<long, EnemyClusterData> targetDataTable);

	private static void SetupEnemyClusterDataTableIndexGenerated(DataTable<long, EnemyClusterData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EnemyClusterData GetDataById(long id)
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

