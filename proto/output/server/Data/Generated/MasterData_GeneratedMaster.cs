using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwsDotnetCsharp
{
	public partial class MasterData
	{
		public async Task LoadFromDB()
		{
			await this.clientMaster.LoadFromDB();
			this.enemyClusters = await EnemyClusterData.DbGetDataList();
			this.enemyMappings = await EnemyMappingData.DbGetDataList();
			this.eventQuestCategorys = await EventQuestCategoryData.DbGetDataList();
			this.eventScheduleTerms = await EventScheduleTermData.DbGetDataList();
			this.gachaPools = await GachaPoolData.DbGetDataList();
			this.gachaPoolItems = await GachaPoolItemData.DbGetDataList();
		}

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
}
