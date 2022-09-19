using System.Collections.Generic;


public partial class SkillData : IUnique<long>
{
	#region NullObject
	public static SkillData Null => NullObjectContainer.Get<SkillData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, SkillData> dataTable {
		get {
			DataTable<long, SkillData> result;
			if (GameDb.TableExists<long, SkillData>()) {
				result = GameDb.From<long, SkillData>();
			} else {
				result = GameDb.CreateTable<long, SkillData>();
				SetupSkillDataTableIndexGenerated(result);
				SetupSkillDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<SkillData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(SkillData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<SkillData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<SkillData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupSkillDataTableIndex(DataTable<long, SkillData> targetDataTable);

	private static void SetupSkillDataTableIndexGenerated(DataTable<long, SkillData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
		targetDataTable.CreateIndex("Skilldata", aData => (object)aData.skilldata);
	}
	#endregion
}
