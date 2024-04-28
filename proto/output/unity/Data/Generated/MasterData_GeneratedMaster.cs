using System;

public partial class MasterData
{
	public void SetToGameDb()
	{
		clientMaster.SetToGameDb();
		EnemyClusterData.SetDataList(enemyClusters);
		EnemyMappingData.SetDataList(enemyMappings);
		EventQuestCategoryData.SetDataList(eventQuestCategorys);
		EventScheduleTermData.SetDataList(eventScheduleTerms);
		GachaPoolData.SetDataList(gachaPools);
		GachaPoolItemData.SetDataList(gachaPoolItems);
	}
}
