using System.Collections.Generic;

public partial class AdviceData : IUnique<long>
{
	#region NullObject
	public static AdviceData Null => NullObjectContainer.Get<AdviceData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, AdviceData> dataTable {
		get {
			DataTable<long, AdviceData> result;
			if (GameDb.TableExists<long, AdviceData>()) {
				result = GameDb.From<long, AdviceData>();
			} else {
				result = GameDb.CreateTable<long, AdviceData>();
				SetupAdviceDataTableIndexGenerated(result);
				SetupAdviceDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<AdviceData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(AdviceData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<AdviceData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<AdviceData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupAdviceDataTableIndex(DataTable<long, AdviceData> targetDataTable);

	private static void SetupAdviceDataTableIndexGenerated(DataTable<long, AdviceData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static AdviceData GetDataById(long id)
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

