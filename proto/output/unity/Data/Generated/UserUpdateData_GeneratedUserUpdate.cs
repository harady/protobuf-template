using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public partial class UserUpdateData
{
	public void SetToGameDb()
	{
		UserDataManager.instance.userData = user;
		UserBackupData.SetDataList(userBackups);
		UserDeckData.SetDataList(userDecks);
		UserExchangeItemData.SetDataList(userExchangeItems);
		UserGachaButtonData.SetDataList(userGachaButtons);
		UserItemData.SetDataList(userItems);
		UserMessageData.SetDataList(userMessages);
		UserMissionData.SetDataList(userMissions);
		UserPaidCrystalData.SetDataList(userPaidCrystals);
		UserShopItemData.SetDataList(userShopItems);
		UserStageData.SetDataList(userStages);
		UserUnitData.SetDataList(userUnits);
		UserUnitCollectionData.SetDataList(userUnitCollections);
		RemoveFromGameDb();
	}
	
	public void AddToGameDb()
	{
		UserDataManager.instance.userData = user;
		UserBackupData.AddDataList(userBackups);
		UserDeckData.AddDataList(userDecks);
		UserExchangeItemData.AddDataList(userExchangeItems);
		UserGachaButtonData.AddDataList(userGachaButtons);
		UserItemData.AddDataList(userItems);
		UserMessageData.AddDataList(userMessages);
		UserMissionData.AddDataList(userMissions);
		UserPaidCrystalData.AddDataList(userPaidCrystals);
		UserShopItemData.AddDataList(userShopItems);
		UserStageData.AddDataList(userStages);
		UserUnitData.AddDataList(userUnits);
		UserUnitCollectionData.AddDataList(userUnitCollections);
		RemoveFromGameDb();
	}

	public void RemoveFromGameDb()
	{
		UserBackupData.RemoveDataByIds(deletedUserBackupIds);
		UserDeckData.RemoveDataByIds(deletedUserDeckIds);
		UserExchangeItemData.RemoveDataByIds(deletedUserExchangeItemIds);
		UserGachaButtonData.RemoveDataByIds(deletedUserGachaButtonIds);
		UserItemData.RemoveDataByIds(deletedUserItemIds);
		UserMessageData.RemoveDataByIds(deletedUserMessageIds);
		UserMissionData.RemoveDataByIds(deletedUserMissionIds);
		UserPaidCrystalData.RemoveDataByIds(deletedUserPaidCrystalIds);
		UserShopItemData.RemoveDataByIds(deletedUserShopItemIds);
		UserStageData.RemoveDataByIds(deletedUserStageIds);
		UserUnitData.RemoveDataByIds(deletedUserUnitIds);
		UserUnitCollectionData.RemoveDataByIds(deletedUserUnitCollectionIds);
	}

	[DataMember(Name = "deletedUserBackupIds")]
	public List<long> deletedUserBackupIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserDeckIds")]
	public List<long> deletedUserDeckIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserExchangeItemIds")]
	public List<long> deletedUserExchangeItemIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserGachaButtonIds")]
	public List<long> deletedUserGachaButtonIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserItemIds")]
	public List<long> deletedUserItemIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserMessageIds")]
	public List<long> deletedUserMessageIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserMissionIds")]
	public List<long> deletedUserMissionIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserPaidCrystalIds")]
	public List<long> deletedUserPaidCrystalIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserShopItemIds")]
	public List<long> deletedUserShopItemIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserStageIds")]
	public List<long> deletedUserStageIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserUnitIds")]
	public List<long> deletedUserUnitIds { get; set; } = new List<long>();

	[DataMember(Name = "deletedUserUnitCollectionIds")]
	public List<long> deletedUserUnitCollectionIds { get; set; } = new List<long>();
}
