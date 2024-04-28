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
	public partial class UserUpdateData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("user")]
		[DataMember(Name = "user")]
		public UserData user { get; set; }

		[BsonElement("userBackups")]
		[DataMember(Name = "userBackups")]
		public List<UserBackupData> userBackups { get; set; } = new List<UserBackupData>();

		[BsonElement("userDecks")]
		[DataMember(Name = "userDecks")]
		public List<UserDeckData> userDecks { get; set; } = new List<UserDeckData>();

		[BsonElement("userExchangeItems")]
		[DataMember(Name = "userExchangeItems")]
		public List<UserExchangeItemData> userExchangeItems { get; set; } = new List<UserExchangeItemData>();

		[BsonElement("userGachaButtons")]
		[DataMember(Name = "userGachaButtons")]
		public List<UserGachaButtonData> userGachaButtons { get; set; } = new List<UserGachaButtonData>();

		[BsonElement("userItems")]
		[DataMember(Name = "userItems")]
		public List<UserItemData> userItems { get; set; } = new List<UserItemData>();

		[BsonElement("userMessages")]
		[DataMember(Name = "userMessages")]
		public List<UserMessageData> userMessages { get; set; } = new List<UserMessageData>();

		[BsonElement("userMissions")]
		[DataMember(Name = "userMissions")]
		public List<UserMissionData> userMissions { get; set; } = new List<UserMissionData>();

		[BsonElement("userPaidCrystals")]
		[DataMember(Name = "userPaidCrystals")]
		public List<UserPaidCrystalData> userPaidCrystals { get; set; } = new List<UserPaidCrystalData>();

		[BsonElement("userShopItems")]
		[DataMember(Name = "userShopItems")]
		public List<UserShopItemData> userShopItems { get; set; } = new List<UserShopItemData>();

		[BsonElement("userStages")]
		[DataMember(Name = "userStages")]
		public List<UserStageData> userStages { get; set; } = new List<UserStageData>();

		[BsonElement("userUnits")]
		[DataMember(Name = "userUnits")]
		public List<UserUnitData> userUnits { get; set; } = new List<UserUnitData>();

		[BsonElement("userUnitCollections")]
		[DataMember(Name = "userUnitCollections")]
		public List<UserUnitCollectionData> userUnitCollections { get; set; } = new List<UserUnitCollectionData>();

	}
}
