using System.Collections.Generic;

public partial class EquipmentData : IUnique<long>
{
	#region NullObject
	public static EquipmentData Null => NullObjectContainer.Get<EquipmentData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EquipmentData> dataTable {
		get {
			DataTable<long, EquipmentData> result;
			if (GameDb.TableExists<long, EquipmentData>()) {
				result = GameDb.From<long, EquipmentData>();
			} else {
				result = GameDb.CreateTable<long, EquipmentData>();
				SetupEquipmentDataTableIndexGenerated(result);
				SetupEquipmentDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EquipmentData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EquipmentData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EquipmentData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EquipmentData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEquipmentDataTableIndex(DataTable<long, EquipmentData> targetDataTable);

	private static void SetupEquipmentDataTableIndexGenerated(DataTable<long, EquipmentData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static EquipmentData GetDataById(long id)
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

