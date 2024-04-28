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
	public partial class UserBattleData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("stageId")]
		[DataMember(Name = "stageId")]
		public long stageId { get; set; }

		[BsonElement("continueCount")]
		[DataMember(Name = "continueCount")]
		public long continueCount { get; set; }

		[BsonElement("battleClientData")]
		[DataMember(Name = "battleClientData")]
		public BattleClientData battleClientData { get; set; }

		[BsonElement("battleServerData")]
		[DataMember(Name = "battleServerData")]
		public BattleServerData battleServerData { get; set; }

		[BsonElement("startAt")]
		[DataMember(Name = "startAt")]
		public long startAt { get; set; }
		[BsonIgnore]
		public DateTime StartAt {
			get { return DateTimeUtil.FromEpochTime(startAt); }
			set { startAt = value.ToEpochTime(); }
		}

	}
}
