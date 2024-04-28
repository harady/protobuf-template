using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AwsDotnetCsharp
{
	public partial class UserUpdateData
	{
		public async Task LoadAll(UserData user)
		{
			this.user = user ?? throw new APIException(message: "ユーザーが存在しません.");
			this.userBackups = await UserBackupData.DbGetDataListByUserId(this.user.id);
			this.userDecks = await UserDeckData.DbGetDataListByUserId(this.user.id);
			this.userExchangeItems = await UserExchangeItemData.DbGetDataListByUserId(this.user.id);
			this.userGachaButtons = await UserGachaButtonData.DbGetDataListByUserId(this.user.id);
			this.userItems = await UserItemData.DbGetDataListByUserId(this.user.id);
			this.userMessages = await UserMessageData.DbGetDataListByUserId(this.user.id);
			this.userMissions = await UserMissionData.DbGetDataListByUserId(this.user.id);
			this.userPaidCrystals = await UserPaidCrystalData.DbGetDataListByUserId(this.user.id);
			this.userShopItems = await UserShopItemData.DbGetDataListByUserId(this.user.id);
			this.userStages = await UserStageData.DbGetDataListByUserId(this.user.id);
			this.userUnits = await UserUnitData.DbGetDataListByUserId(this.user.id);
			this.userUnitCollections = await UserUnitCollectionData.DbGetDataListByUserId(this.user.id);
		}

		public void Merge(UserUpdateData toMerge)
		{
			if (toMerge.user != null) {
				this.user = toMerge.user;
			}
			this.userBackups.Merge(toMerge.userBackups);
			this.deletedUserBackupIds.Merge(toMerge.deletedUserBackupIds);
			this.userDecks.Merge(toMerge.userDecks);
			this.deletedUserDeckIds.Merge(toMerge.deletedUserDeckIds);
			this.userExchangeItems.Merge(toMerge.userExchangeItems);
			this.deletedUserExchangeItemIds.Merge(toMerge.deletedUserExchangeItemIds);
			this.userGachaButtons.Merge(toMerge.userGachaButtons);
			this.deletedUserGachaButtonIds.Merge(toMerge.deletedUserGachaButtonIds);
			this.userItems.Merge(toMerge.userItems);
			this.deletedUserItemIds.Merge(toMerge.deletedUserItemIds);
			this.userMessages.Merge(toMerge.userMessages);
			this.deletedUserMessageIds.Merge(toMerge.deletedUserMessageIds);
			this.userMissions.Merge(toMerge.userMissions);
			this.deletedUserMissionIds.Merge(toMerge.deletedUserMissionIds);
			this.userPaidCrystals.Merge(toMerge.userPaidCrystals);
			this.deletedUserPaidCrystalIds.Merge(toMerge.deletedUserPaidCrystalIds);
			this.userShopItems.Merge(toMerge.userShopItems);
			this.deletedUserShopItemIds.Merge(toMerge.deletedUserShopItemIds);
			this.userStages.Merge(toMerge.userStages);
			this.deletedUserStageIds.Merge(toMerge.deletedUserStageIds);
			this.userUnits.Merge(toMerge.userUnits);
			this.deletedUserUnitIds.Merge(toMerge.deletedUserUnitIds);
			this.userUnitCollections.Merge(toMerge.userUnitCollections);
			this.deletedUserUnitCollectionIds.Merge(toMerge.deletedUserUnitCollectionIds);
		}

		[BsonElement("deletedUserBackupIds")]
		[DataMember(Name = "deletedUserBackupIds")]
		public List<long> deletedUserBackupIds { get; set; } = new List<long>();

		[BsonElement("deletedUserDeckIds")]
		[DataMember(Name = "deletedUserDeckIds")]
		public List<long> deletedUserDeckIds { get; set; } = new List<long>();

		[BsonElement("deletedUserExchangeItemIds")]
		[DataMember(Name = "deletedUserExchangeItemIds")]
		public List<long> deletedUserExchangeItemIds { get; set; } = new List<long>();

		[BsonElement("deletedUserGachaButtonIds")]
		[DataMember(Name = "deletedUserGachaButtonIds")]
		public List<long> deletedUserGachaButtonIds { get; set; } = new List<long>();

		[BsonElement("deletedUserItemIds")]
		[DataMember(Name = "deletedUserItemIds")]
		public List<long> deletedUserItemIds { get; set; } = new List<long>();

		[BsonElement("deletedUserMessageIds")]
		[DataMember(Name = "deletedUserMessageIds")]
		public List<long> deletedUserMessageIds { get; set; } = new List<long>();

		[BsonElement("deletedUserMissionIds")]
		[DataMember(Name = "deletedUserMissionIds")]
		public List<long> deletedUserMissionIds { get; set; } = new List<long>();

		[BsonElement("deletedUserPaidCrystalIds")]
		[DataMember(Name = "deletedUserPaidCrystalIds")]
		public List<long> deletedUserPaidCrystalIds { get; set; } = new List<long>();

		[BsonElement("deletedUserShopItemIds")]
		[DataMember(Name = "deletedUserShopItemIds")]
		public List<long> deletedUserShopItemIds { get; set; } = new List<long>();

		[BsonElement("deletedUserStageIds")]
		[DataMember(Name = "deletedUserStageIds")]
		public List<long> deletedUserStageIds { get; set; } = new List<long>();

		[BsonElement("deletedUserUnitIds")]
		[DataMember(Name = "deletedUserUnitIds")]
		public List<long> deletedUserUnitIds { get; set; } = new List<long>();

		[BsonElement("deletedUserUnitCollectionIds")]
		[DataMember(Name = "deletedUserUnitCollectionIds")]
		public List<long> deletedUserUnitCollectionIds { get; set; } = new List<long>();

		public TableUpdateData<UserBackupData> userBackupTableUpdate
			=> new TableUpdateData<UserBackupData>(userBackups, deletedUserBackupIds);

		public TableUpdateData<UserDeckData> userDeckTableUpdate
			=> new TableUpdateData<UserDeckData>(userDecks, deletedUserDeckIds);

		public TableUpdateData<UserExchangeItemData> userExchangeItemTableUpdate
			=> new TableUpdateData<UserExchangeItemData>(userExchangeItems, deletedUserExchangeItemIds);

		public TableUpdateData<UserGachaButtonData> userGachaButtonTableUpdate
			=> new TableUpdateData<UserGachaButtonData>(userGachaButtons, deletedUserGachaButtonIds);

		public TableUpdateData<UserItemData> userItemTableUpdate
			=> new TableUpdateData<UserItemData>(userItems, deletedUserItemIds);

		public TableUpdateData<UserMessageData> userMessageTableUpdate
			=> new TableUpdateData<UserMessageData>(userMessages, deletedUserMessageIds);

		public TableUpdateData<UserMissionData> userMissionTableUpdate
			=> new TableUpdateData<UserMissionData>(userMissions, deletedUserMissionIds);

		public TableUpdateData<UserPaidCrystalData> userPaidCrystalTableUpdate
			=> new TableUpdateData<UserPaidCrystalData>(userPaidCrystals, deletedUserPaidCrystalIds);

		public TableUpdateData<UserShopItemData> userShopItemTableUpdate
			=> new TableUpdateData<UserShopItemData>(userShopItems, deletedUserShopItemIds);

		public TableUpdateData<UserStageData> userStageTableUpdate
			=> new TableUpdateData<UserStageData>(userStages, deletedUserStageIds);

		public TableUpdateData<UserUnitData> userUnitTableUpdate
			=> new TableUpdateData<UserUnitData>(userUnits, deletedUserUnitIds);

		public TableUpdateData<UserUnitCollectionData> userUnitCollectionTableUpdate
			=> new TableUpdateData<UserUnitCollectionData>(userUnitCollections, deletedUserUnitCollectionIds);
	}
}
