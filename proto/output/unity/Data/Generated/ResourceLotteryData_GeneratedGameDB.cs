using System.Collections.Generic;

public partial class ResourceLotteryData : IUnique<long>
{
	#region NullObject
	public static ResourceLotteryData Null => NullObjectContainer.Get<ResourceLotteryData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ResourceLotteryData> dataTable {
		get {
			DataTable<long, ResourceLotteryData> result;
			if (GameDb.TableExists<long, ResourceLotteryData>()) {
				result = GameDb.From<long, ResourceLotteryData>();
			} else {
				result = GameDb.CreateTable<long, ResourceLotteryData>();
				SetupResourceLotteryDataTableIndexGenerated(result);
				SetupResourceLotteryDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ResourceLotteryData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ResourceLotteryData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ResourceLotteryData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ResourceLotteryData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupResourceLotteryDataTableIndex(DataTable<long, ResourceLotteryData> targetDataTable);

	private static void SetupResourceLotteryDataTableIndexGenerated(DataTable<long, ResourceLotteryData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static ResourceLotteryData GetDataById(long id)
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

