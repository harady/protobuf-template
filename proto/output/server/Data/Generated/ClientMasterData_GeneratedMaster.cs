using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwsDotnetCsharp
{
	public partial class ClientMasterData
	{
		public async Task LoadFromDB()
		{
			this.enemys = await EnemyData.DbGetDataList();
			this.enemyActions = await EnemyActionData.DbGetDataList();
			this.rounds = await RoundData.DbGetDataList();
			this.weakPoints = await WeakPointData.DbGetDataList();
			this.weakPointPositions = await WeakPointPositionData.DbGetDataList();
			this.canpaigns = await CanpaignData.DbGetDataList();
			this.configs = await ConfigData.DbGetDataList();
			this.identifableItems = await IdentifableItemData.DbGetDataList();
			this.items = await ItemData.DbGetDataList();
			this.resourceLotterys = await ResourceLotteryData.DbGetDataList();
			this.resourceLotteryItems = await ResourceLotteryItemData.DbGetDataList();
			this.resourceSets = await ResourceSetData.DbGetDataList();
			this.resourceSetItems = await ResourceSetItemData.DbGetDataList();
			this.dailyEventTables = await DailyEventTableData.DbGetDataList();
			this.dailyEventTableItems = await DailyEventTableItemData.DbGetDataList();
			this.gachas = await GachaData.DbGetDataList();
			this.gachaButtons = await GachaButtonData.DbGetDataList();
			this.gachaSchedules = await GachaScheduleData.DbGetDataList();
			this.messages = await MessageData.DbGetDataList();
			this.missions = await MissionData.DbGetDataList();
			this.missionGroups = await MissionGroupData.DbGetDataList();
			this.missionSchedules = await MissionScheduleData.DbGetDataList();
			this.advices = await AdviceData.DbGetDataList();
			this.logs = await LogData.DbGetDataList();
			this.loginBonuss = await LoginBonusData.DbGetDataList();
			this.loginBonusItems = await LoginBonusItemData.DbGetDataList();
			this.userRankExps = await UserRankExpData.DbGetDataList();
			this.versions = await VersionData.DbGetDataList();
			this.eventSchedules = await EventScheduleData.DbGetDataList();
			this.quests = await QuestData.DbGetDataList();
			this.questGroups = await QuestGroupData.DbGetDataList();
			this.stages = await StageData.DbGetDataList();
			this.stageSpecialRewards = await StageSpecialRewardData.DbGetDataList();
			this.exchanges = await ExchangeData.DbGetDataList();
			this.exchangeItems = await ExchangeItemData.DbGetDataList();
			this.exchangeSchedules = await ExchangeScheduleData.DbGetDataList();
			this.shops = await ShopData.DbGetDataList();
			this.shopItems = await ShopItemData.DbGetDataList();
			this.shopSchedules = await ShopScheduleData.DbGetDataList();
			this.abilitys = await AbilityData.DbGetDataList();
			this.combos = await ComboData.DbGetDataList();
			this.equipments = await EquipmentData.DbGetDataList();
			this.skills = await SkillData.DbGetDataList();
			this.units = await UnitData.DbGetDataList();
			this.unitCategorys = await UnitCategoryData.DbGetDataList();
			this.unitEvolutions = await UnitEvolutionData.DbGetDataList();
			this.unitLevelExps = await UnitLevelExpData.DbGetDataList();
		}

		public void SetToGameDb()
		{
			EnemyData.SetDataList(enemys);
			EnemyActionData.SetDataList(enemyActions);
			RoundData.SetDataList(rounds);
			WeakPointData.SetDataList(weakPoints);
			WeakPointPositionData.SetDataList(weakPointPositions);
			CanpaignData.SetDataList(canpaigns);
			ConfigData.SetDataList(configs);
			IdentifableItemData.SetDataList(identifableItems);
			ItemData.SetDataList(items);
			ResourceLotteryData.SetDataList(resourceLotterys);
			ResourceLotteryItemData.SetDataList(resourceLotteryItems);
			ResourceSetData.SetDataList(resourceSets);
			ResourceSetItemData.SetDataList(resourceSetItems);
			DailyEventTableData.SetDataList(dailyEventTables);
			DailyEventTableItemData.SetDataList(dailyEventTableItems);
			GachaData.SetDataList(gachas);
			GachaButtonData.SetDataList(gachaButtons);
			GachaScheduleData.SetDataList(gachaSchedules);
			MessageData.SetDataList(messages);
			MissionData.SetDataList(missions);
			MissionGroupData.SetDataList(missionGroups);
			MissionScheduleData.SetDataList(missionSchedules);
			AdviceData.SetDataList(advices);
			LogData.SetDataList(logs);
			LoginBonusData.SetDataList(loginBonuss);
			LoginBonusItemData.SetDataList(loginBonusItems);
			UserRankExpData.SetDataList(userRankExps);
			VersionData.SetDataList(versions);
			EventScheduleData.SetDataList(eventSchedules);
			QuestData.SetDataList(quests);
			QuestGroupData.SetDataList(questGroups);
			StageData.SetDataList(stages);
			StageSpecialRewardData.SetDataList(stageSpecialRewards);
			ExchangeData.SetDataList(exchanges);
			ExchangeItemData.SetDataList(exchangeItems);
			ExchangeScheduleData.SetDataList(exchangeSchedules);
			ShopData.SetDataList(shops);
			ShopItemData.SetDataList(shopItems);
			ShopScheduleData.SetDataList(shopSchedules);
			AbilityData.SetDataList(abilitys);
			ComboData.SetDataList(combos);
			EquipmentData.SetDataList(equipments);
			SkillData.SetDataList(skills);
			UnitData.SetDataList(units);
			UnitCategoryData.SetDataList(unitCategorys);
			UnitEvolutionData.SetDataList(unitEvolutions);
			UnitLevelExpData.SetDataList(unitLevelExps);
		}
	}
}
