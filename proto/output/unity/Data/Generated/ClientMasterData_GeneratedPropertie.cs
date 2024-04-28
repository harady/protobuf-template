using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ClientMasterData : AbstractData
{
	[DataMember(Name = "enemys")]
	public List<EnemyData> enemys { get; set; } = new List<EnemyData>();

	[DataMember(Name = "enemyActions")]
	public List<EnemyActionData> enemyActions { get; set; } = new List<EnemyActionData>();

	[DataMember(Name = "rounds")]
	public List<RoundData> rounds { get; set; } = new List<RoundData>();

	[DataMember(Name = "weakPoints")]
	public List<WeakPointData> weakPoints { get; set; } = new List<WeakPointData>();

	[DataMember(Name = "weakPointPositions")]
	public List<WeakPointPositionData> weakPointPositions { get; set; } = new List<WeakPointPositionData>();

	[DataMember(Name = "canpaigns")]
	public List<CanpaignData> canpaigns { get; set; } = new List<CanpaignData>();

	[DataMember(Name = "configs")]
	public List<ConfigData> configs { get; set; } = new List<ConfigData>();

	[DataMember(Name = "identifableItems")]
	public List<IdentifableItemData> identifableItems { get; set; } = new List<IdentifableItemData>();

	[DataMember(Name = "items")]
	public List<ItemData> items { get; set; } = new List<ItemData>();

	[DataMember(Name = "resourceLotterys")]
	public List<ResourceLotteryData> resourceLotterys { get; set; } = new List<ResourceLotteryData>();

	[DataMember(Name = "resourceLotteryItems")]
	public List<ResourceLotteryItemData> resourceLotteryItems { get; set; } = new List<ResourceLotteryItemData>();

	[DataMember(Name = "resourceSets")]
	public List<ResourceSetData> resourceSets { get; set; } = new List<ResourceSetData>();

	[DataMember(Name = "resourceSetItems")]
	public List<ResourceSetItemData> resourceSetItems { get; set; } = new List<ResourceSetItemData>();

	[DataMember(Name = "dailyEventTables")]
	public List<DailyEventTableData> dailyEventTables { get; set; } = new List<DailyEventTableData>();

	[DataMember(Name = "dailyEventTableItems")]
	public List<DailyEventTableItemData> dailyEventTableItems { get; set; } = new List<DailyEventTableItemData>();

	[DataMember(Name = "gachas")]
	public List<GachaData> gachas { get; set; } = new List<GachaData>();

	[DataMember(Name = "gachaButtons")]
	public List<GachaButtonData> gachaButtons { get; set; } = new List<GachaButtonData>();

	[DataMember(Name = "gachaSchedules")]
	public List<GachaScheduleData> gachaSchedules { get; set; } = new List<GachaScheduleData>();

	[DataMember(Name = "messages")]
	public List<MessageData> messages { get; set; } = new List<MessageData>();

	[DataMember(Name = "missions")]
	public List<MissionData> missions { get; set; } = new List<MissionData>();

	[DataMember(Name = "missionGroups")]
	public List<MissionGroupData> missionGroups { get; set; } = new List<MissionGroupData>();

	[DataMember(Name = "missionSchedules")]
	public List<MissionScheduleData> missionSchedules { get; set; } = new List<MissionScheduleData>();

	[DataMember(Name = "advices")]
	public List<AdviceData> advices { get; set; } = new List<AdviceData>();

	[DataMember(Name = "logs")]
	public List<LogData> logs { get; set; } = new List<LogData>();

	[DataMember(Name = "loginBonuss")]
	public List<LoginBonusData> loginBonuss { get; set; } = new List<LoginBonusData>();

	[DataMember(Name = "loginBonusItems")]
	public List<LoginBonusItemData> loginBonusItems { get; set; } = new List<LoginBonusItemData>();

	[DataMember(Name = "userRankExps")]
	public List<UserRankExpData> userRankExps { get; set; } = new List<UserRankExpData>();

	[DataMember(Name = "versions")]
	public List<VersionData> versions { get; set; } = new List<VersionData>();

	[DataMember(Name = "eventSchedules")]
	public List<EventScheduleData> eventSchedules { get; set; } = new List<EventScheduleData>();

	[DataMember(Name = "quests")]
	public List<QuestData> quests { get; set; } = new List<QuestData>();

	[DataMember(Name = "questGroups")]
	public List<QuestGroupData> questGroups { get; set; } = new List<QuestGroupData>();

	[DataMember(Name = "stages")]
	public List<StageData> stages { get; set; } = new List<StageData>();

	[DataMember(Name = "stageSpecialRewards")]
	public List<StageSpecialRewardData> stageSpecialRewards { get; set; } = new List<StageSpecialRewardData>();

	[DataMember(Name = "exchanges")]
	public List<ExchangeData> exchanges { get; set; } = new List<ExchangeData>();

	[DataMember(Name = "exchangeItems")]
	public List<ExchangeItemData> exchangeItems { get; set; } = new List<ExchangeItemData>();

	[DataMember(Name = "exchangeSchedules")]
	public List<ExchangeScheduleData> exchangeSchedules { get; set; } = new List<ExchangeScheduleData>();

	[DataMember(Name = "shops")]
	public List<ShopData> shops { get; set; } = new List<ShopData>();

	[DataMember(Name = "shopItems")]
	public List<ShopItemData> shopItems { get; set; } = new List<ShopItemData>();

	[DataMember(Name = "shopSchedules")]
	public List<ShopScheduleData> shopSchedules { get; set; } = new List<ShopScheduleData>();

	[DataMember(Name = "abilitys")]
	public List<AbilityData> abilitys { get; set; } = new List<AbilityData>();

	[DataMember(Name = "combos")]
	public List<ComboData> combos { get; set; } = new List<ComboData>();

	[DataMember(Name = "equipments")]
	public List<EquipmentData> equipments { get; set; } = new List<EquipmentData>();

	[DataMember(Name = "skills")]
	public List<SkillData> skills { get; set; } = new List<SkillData>();

	[DataMember(Name = "units")]
	public List<UnitData> units { get; set; } = new List<UnitData>();

	[DataMember(Name = "unitCategorys")]
	public List<UnitCategoryData> unitCategorys { get; set; } = new List<UnitCategoryData>();

	[DataMember(Name = "unitEvolutions")]
	public List<UnitEvolutionData> unitEvolutions { get; set; } = new List<UnitEvolutionData>();

	[DataMember(Name = "unitLevelExps")]
	public List<UnitLevelExpData> unitLevelExps { get; set; } = new List<UnitLevelExpData>();

	public ClientMasterData Clone() {
		var result = new ClientMasterData();
		result.enemys = enemys;
		result.enemyActions = enemyActions;
		result.rounds = rounds;
		result.weakPoints = weakPoints;
		result.weakPointPositions = weakPointPositions;
		result.canpaigns = canpaigns;
		result.configs = configs;
		result.identifableItems = identifableItems;
		result.items = items;
		result.resourceLotterys = resourceLotterys;
		result.resourceLotteryItems = resourceLotteryItems;
		result.resourceSets = resourceSets;
		result.resourceSetItems = resourceSetItems;
		result.dailyEventTables = dailyEventTables;
		result.dailyEventTableItems = dailyEventTableItems;
		result.gachas = gachas;
		result.gachaButtons = gachaButtons;
		result.gachaSchedules = gachaSchedules;
		result.messages = messages;
		result.missions = missions;
		result.missionGroups = missionGroups;
		result.missionSchedules = missionSchedules;
		result.advices = advices;
		result.logs = logs;
		result.loginBonuss = loginBonuss;
		result.loginBonusItems = loginBonusItems;
		result.userRankExps = userRankExps;
		result.versions = versions;
		result.eventSchedules = eventSchedules;
		result.quests = quests;
		result.questGroups = questGroups;
		result.stages = stages;
		result.stageSpecialRewards = stageSpecialRewards;
		result.exchanges = exchanges;
		result.exchangeItems = exchangeItems;
		result.exchangeSchedules = exchangeSchedules;
		result.shops = shops;
		result.shopItems = shopItems;
		result.shopSchedules = shopSchedules;
		result.abilitys = abilitys;
		result.combos = combos;
		result.equipments = equipments;
		result.skills = skills;
		result.units = units;
		result.unitCategorys = unitCategorys;
		result.unitEvolutions = unitEvolutions;
		result.unitLevelExps = unitLevelExps;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
