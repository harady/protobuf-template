using System.Collections.Generic;

public partial class CanpaignData : IUnique<long>
{
	#region NullObject
	public static CanpaignData Null => NullObjectContainer.Get<CanpaignData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, CanpaignData> dataTable {
		get {
			DataTable<long, CanpaignData> result;
			if (GameDb.TableExists<long, CanpaignData>()) {
				result = GameDb.From<long, CanpaignData>();
			} else {
				result = GameDb.CreateTable<long, CanpaignData>();
				SetupCanpaignDataTableIndexGenerated(result);
				SetupCanpaignDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<CanpaignData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(CanpaignData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<CanpaignData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<CanpaignData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupCanpaignDataTableIndex(DataTable<long, CanpaignData> targetDataTable);

	private static void SetupCanpaignDataTableIndexGenerated(DataTable<long, CanpaignData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static CanpaignData GetDataById(long id)
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

