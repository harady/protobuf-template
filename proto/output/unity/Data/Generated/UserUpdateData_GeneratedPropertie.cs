using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUpdateData : AbstractData
{
	[DataMember(Name = "user")]
	public UserData user { get; set; }

	[DataMember(Name = "userBackups")]
	public List<UserBackupData> userBackups { get; set; } = new List<UserBackupData>();

	[DataMember(Name = "userDecks")]
	public List<UserDeckData> userDecks { get; set; } = new List<UserDeckData>();

	[DataMember(Name = "userExchangeItems")]
	public List<UserExchangeItemData> userExchangeItems { get; set; } = new List<UserExchangeItemData>();

	[DataMember(Name = "userGachaButtons")]
	public List<UserGachaButtonData> userGachaButtons { get; set; } = new List<UserGachaButtonData>();

	[DataMember(Name = "userItems")]
	public List<UserItemData> userItems { get; set; } = new List<UserItemData>();

	[DataMember(Name = "userMessages")]
	public List<UserMessageData> userMessages { get; set; } = new List<UserMessageData>();

	[DataMember(Name = "userMissions")]
	public List<UserMissionData> userMissions { get; set; } = new List<UserMissionData>();

	[DataMember(Name = "userPaidCrystals")]
	public List<UserPaidCrystalData> userPaidCrystals { get; set; } = new List<UserPaidCrystalData>();

	[DataMember(Name = "userShopItems")]
	public List<UserShopItemData> userShopItems { get; set; } = new List<UserShopItemData>();

	[DataMember(Name = "userStages")]
	public List<UserStageData> userStages { get; set; } = new List<UserStageData>();

	[DataMember(Name = "userUnits")]
	public List<UserUnitData> userUnits { get; set; } = new List<UserUnitData>();

	[DataMember(Name = "userUnitCollections")]
	public List<UserUnitCollectionData> userUnitCollections { get; set; } = new List<UserUnitCollectionData>();

	public UserUpdateData Clone() {
		var result = new UserUpdateData();
		result.user = user;
		result.userBackups = userBackups;
		result.userDecks = userDecks;
		result.userExchangeItems = userExchangeItems;
		result.userGachaButtons = userGachaButtons;
		result.userItems = userItems;
		result.userMessages = userMessages;
		result.userMissions = userMissions;
		result.userPaidCrystals = userPaidCrystals;
		result.userShopItems = userShopItems;
		result.userStages = userStages;
		result.userUnits = userUnits;
		result.userUnitCollections = userUnitCollections;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
