using System.Collections.Generic;

public partial class MessageData : IUnique<long>
{
	#region NullObject
	public static MessageData Null => NullObjectContainer.Get<MessageData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, MessageData> dataTable {
		get {
			DataTable<long, MessageData> result;
			if (GameDb.TableExists<long, MessageData>()) {
				result = GameDb.From<long, MessageData>();
			} else {
				result = GameDb.CreateTable<long, MessageData>();
				SetupMessageDataTableIndexGenerated(result);
				SetupMessageDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<MessageData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(MessageData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<MessageData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<MessageData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupMessageDataTableIndex(DataTable<long, MessageData> targetDataTable);

	private static void SetupMessageDataTableIndexGenerated(DataTable<long, MessageData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static MessageData GetDataById(long id)
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

