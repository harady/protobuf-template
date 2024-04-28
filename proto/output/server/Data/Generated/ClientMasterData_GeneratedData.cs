using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using MessagePack;

namespace AwsDotnetCsharp
{
	[BsonIgnoreExtraElements]
	[DataContract]
	public partial class ClientMasterData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("enemys")]
		[DataMember(Name = "enemys")]
		public List<EnemyData> enemys { get; set; } = new List<EnemyData>();

		[BsonElement("enemyActions")]
		[DataMember(Name = "enemyActions")]
		public List<EnemyActionData> enemyActions { get; set; } = new List<EnemyActionData>();

		[BsonElement("rounds")]
		[DataMember(Name = "rounds")]
		public List<RoundData> rounds { get; set; } = new List<RoundData>();

		[BsonElement("weakPoints")]
		[DataMember(Name = "weakPoints")]
		public List<WeakPointData> weakPoints { get; set; } = new List<WeakPointData>();

		[BsonElement("weakPointPositions")]
		[DataMember(Name = "weakPointPositions")]
		public List<WeakPointPositionData> weakPointPositions { get; set; } = new List<WeakPointPositionData>();

		[BsonElement("canpaigns")]
		[DataMember(Name = "canpaigns")]
		public List<CanpaignData> canpaigns { get; set; } = new List<CanpaignData>();

		[BsonElement("configs")]
		[DataMember(Name = "configs")]
		public List<ConfigData> configs { get; set; } = new List<ConfigData>();

		[BsonElement("identifableItems")]
		[DataMember(Name = "identifableItems")]
		public List<IdentifableItemData> identifableItems { get; set; } = new List<IdentifableItemData>();

		[BsonElement("items")]
		[DataMember(Name = "items")]
		public List<ItemData> items { get; set; } = new List<ItemData>();

		[BsonElement("resourceLotterys")]
		[DataMember(Name = "resourceLotterys")]
		public List<ResourceLotteryData> resourceLotterys { get; set; } = new List<ResourceLotteryData>();

		[BsonElement("resourceLotteryItems")]
		[DataMember(Name = "resourceLotteryItems")]
		public List<ResourceLotteryItemData> resourceLotteryItems { get; set; } = new List<ResourceLotteryItemData>();

		[BsonElement("resourceSets")]
		[DataMember(Name = "resourceSets")]
		public List<ResourceSetData> resourceSets { get; set; } = new List<ResourceSetData>();

		[BsonElement("resourceSetItems")]
		[DataMember(Name = "resourceSetItems")]
		public List<ResourceSetItemData> resourceSetItems { get; set; } = new List<ResourceSetItemData>();

		[BsonElement("dailyEventTables")]
		[DataMember(Name = "dailyEventTables")]
		public List<DailyEventTableData> dailyEventTables { get; set; } = new List<DailyEventTableData>();

		[BsonElement("dailyEventTableItems")]
		[DataMember(Name = "dailyEventTableItems")]
		public List<DailyEventTableItemData> dailyEventTableItems { get; set; } = new List<DailyEventTableItemData>();

		[BsonElement("gachas")]
		[DataMember(Name = "gachas")]
		public List<GachaData> gachas { get; set; } = new List<GachaData>();

		[BsonElement("gachaButtons")]
		[DataMember(Name = "gachaButtons")]
		public List<GachaButtonData> gachaButtons { get; set; } = new List<GachaButtonData>();

		[BsonElement("gachaSchedules")]
		[DataMember(Name = "gachaSchedules")]
		public List<GachaScheduleData> gachaSchedules { get; set; } = new List<GachaScheduleData>();

		[BsonElement("messages")]
		[DataMember(Name = "messages")]
		public List<MessageData> messages { get; set; } = new List<MessageData>();

		[BsonElement("missions")]
		[DataMember(Name = "missions")]
		public List<MissionData> missions { get; set; } = new List<MissionData>();

		[BsonElement("missionGroups")]
		[DataMember(Name = "missionGroups")]
		public List<MissionGroupData> missionGroups { get; set; } = new List<MissionGroupData>();

		[BsonElement("missionSchedules")]
		[DataMember(Name = "missionSchedules")]
		public List<MissionScheduleData> missionSchedules { get; set; } = new List<MissionScheduleData>();

		[BsonElement("advices")]
		[DataMember(Name = "advices")]
		public List<AdviceData> advices { get; set; } = new List<AdviceData>();

		[BsonElement("logs")]
		[DataMember(Name = "logs")]
		public List<LogData> logs { get; set; } = new List<LogData>();

		[BsonElement("loginBonuss")]
		[DataMember(Name = "loginBonuss")]
		public List<LoginBonusData> loginBonuss { get; set; } = new List<LoginBonusData>();

		[BsonElement("loginBonusItems")]
		[DataMember(Name = "loginBonusItems")]
		public List<LoginBonusItemData> loginBonusItems { get; set; } = new List<LoginBonusItemData>();

		[BsonElement("userRankExps")]
		[DataMember(Name = "userRankExps")]
		public List<UserRankExpData> userRankExps { get; set; } = new List<UserRankExpData>();

		[BsonElement("versions")]
		[DataMember(Name = "versions")]
		public List<VersionData> versions { get; set; } = new List<VersionData>();

		[BsonElement("eventSchedules")]
		[DataMember(Name = "eventSchedules")]
		public List<EventScheduleData> eventSchedules { get; set; } = new List<EventScheduleData>();

		[BsonElement("quests")]
		[DataMember(Name = "quests")]
		public List<QuestData> quests { get; set; } = new List<QuestData>();

		[BsonElement("questGroups")]
		[DataMember(Name = "questGroups")]
		public List<QuestGroupData> questGroups { get; set; } = new List<QuestGroupData>();

		[BsonElement("stages")]
		[DataMember(Name = "stages")]
		public List<StageData> stages { get; set; } = new List<StageData>();

		[BsonElement("stageSpecialRewards")]
		[DataMember(Name = "stageSpecialRewards")]
		public List<StageSpecialRewardData> stageSpecialRewards { get; set; } = new List<StageSpecialRewardData>();

		[BsonElement("exchanges")]
		[DataMember(Name = "exchanges")]
		public List<ExchangeData> exchanges { get; set; } = new List<ExchangeData>();

		[BsonElement("exchangeItems")]
		[DataMember(Name = "exchangeItems")]
		public List<ExchangeItemData> exchangeItems { get; set; } = new List<ExchangeItemData>();

		[BsonElement("exchangeSchedules")]
		[DataMember(Name = "exchangeSchedules")]
		public List<ExchangeScheduleData> exchangeSchedules { get; set; } = new List<ExchangeScheduleData>();

		[BsonElement("shops")]
		[DataMember(Name = "shops")]
		public List<ShopData> shops { get; set; } = new List<ShopData>();

		[BsonElement("shopItems")]
		[DataMember(Name = "shopItems")]
		public List<ShopItemData> shopItems { get; set; } = new List<ShopItemData>();

		[BsonElement("shopSchedules")]
		[DataMember(Name = "shopSchedules")]
		public List<ShopScheduleData> shopSchedules { get; set; } = new List<ShopScheduleData>();

		[BsonElement("abilitys")]
		[DataMember(Name = "abilitys")]
		public List<AbilityData> abilitys { get; set; } = new List<AbilityData>();

		[BsonElement("combos")]
		[DataMember(Name = "combos")]
		public List<ComboData> combos { get; set; } = new List<ComboData>();

		[BsonElement("equipments")]
		[DataMember(Name = "equipments")]
		public List<EquipmentData> equipments { get; set; } = new List<EquipmentData>();

		[BsonElement("skills")]
		[DataMember(Name = "skills")]
		public List<SkillData> skills { get; set; } = new List<SkillData>();

		[BsonElement("units")]
		[DataMember(Name = "units")]
		public List<UnitData> units { get; set; } = new List<UnitData>();

		[BsonElement("unitCategorys")]
		[DataMember(Name = "unitCategorys")]
		public List<UnitCategoryData> unitCategorys { get; set; } = new List<UnitCategoryData>();

		[BsonElement("unitEvolutions")]
		[DataMember(Name = "unitEvolutions")]
		public List<UnitEvolutionData> unitEvolutions { get; set; } = new List<UnitEvolutionData>();

		[BsonElement("unitLevelExps")]
		[DataMember(Name = "unitLevelExps")]
		public List<UnitLevelExpData> unitLevelExps { get; set; } = new List<UnitLevelExpData>();

	}
}
