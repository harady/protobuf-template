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
	public partial class UserData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("token")]
		[DataMember(Name = "token")]
		public string token { get; set; }

		[BsonElement("code")]
		[DataMember(Name = "code")]
		public long code { get; set; }

		[BsonElement("rank")]
		[DataMember(Name = "rank")]
		public long rank { get; set; }

		[BsonElement("exp")]
		[DataMember(Name = "exp")]
		public long exp { get; set; }

		[BsonElement("money")]
		[DataMember(Name = "money")]
		public long money { get; set; }

		[BsonElement("stamina")]
		[DataMember(Name = "stamina")]
		public long stamina { get; set; }

		[BsonElement("lastStaminaUpdateAt")]
		[DataMember(Name = "lastStaminaUpdateAt")]
		public long lastStaminaUpdateAt { get; set; }
		[BsonIgnore]
		public DateTime LastStaminaUpdateAt {
			get { return DateTimeUtil.FromEpochTime(lastStaminaUpdateAt); }
			set { lastStaminaUpdateAt = value.ToEpochTime(); }
		}

		[BsonElement("freeCrystal")]
		[DataMember(Name = "freeCrystal")]
		public long freeCrystal { get; set; }

		[BsonElement("paidCrystal")]
		[DataMember(Name = "paidCrystal")]
		public long paidCrystal { get; set; }

		[BsonElement("currentDeckId")]
		[DataMember(Name = "currentDeckId")]
		public long currentDeckId { get; set; }

		[BsonElement("maxStaminaPlus")]
		[DataMember(Name = "maxStaminaPlus")]
		public long maxStaminaPlus { get; set; }

		[BsonElement("deckNumPlus")]
		[DataMember(Name = "deckNumPlus")]
		public long deckNumPlus { get; set; }

		[BsonElement("maxFriendNumPlus")]
		[DataMember(Name = "maxFriendNumPlus")]
		public long maxFriendNumPlus { get; set; }

		[BsonElement("unitBoxNumPlus")]
		[DataMember(Name = "unitBoxNumPlus")]
		public long unitBoxNumPlus { get; set; }

		[BsonElement("friendUserUnitId")]
		[DataMember(Name = "friendUserUnitId")]
		public long friendUserUnitId { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
