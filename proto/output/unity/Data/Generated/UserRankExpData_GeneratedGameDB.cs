using System.Collections.Generic;

public partial class UserRankExpData : IUnique<long>
{
	#region NullObject
	public static UserRankExpData Null => NullObjectContainer.Get<UserRankExpData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserRankExpData> dataTable {
		get {
			DataTable<long, UserRankExpData> result;
			if (GameDb.TableExists<long, UserRankExpData>()) {
				result = GameDb.From<long, UserRankExpData>();
			} else {
				result = GameDb.CreateTable<long, UserRankExpData>();
				SetupUserRankExpDataTableIndexGenerated(result);
				SetupUserRankExpDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserRankExpData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserRankExpData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserRankExpData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserRankExpData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserRankExpDataTableIndex(DataTable<long, UserRankExpData> targetDataTable);

	private static void SetupUserRankExpDataTableIndexGenerated(DataTable<long, UserRankExpData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateUniqueIndex("Rank", aData => (object)aData.rank);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserRankExpData GetDataById(long id)
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
	#region DataTableUniqueIndex(Rank)
	public static UserRankExpData GetDataByRank(long rank)
	{
		return dataTable.GetData("Rank", (object)rank);
	}

	public static void RemoveDataByRanks(ICollection<long> ranks)
	{
		ranks.ForEach(aRank => RemoveDataByRank(aRank));
	}

	public static void RemoveDataByRank(long rank)
	{
		dataTable.DeleteByKey("Rank", (object)rank);
	}
	#endregion
}

