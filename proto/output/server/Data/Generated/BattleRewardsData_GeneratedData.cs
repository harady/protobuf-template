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
	public partial class BattleRewardsData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("stageId")]
		[DataMember(Name = "stageId")]
		public long stageId { get; set; }

		[BsonElement("specialRewards")]
		[DataMember(Name = "specialRewards")]
		public BattleRewardsSpecialRewardsData specialRewards { get; set; }

		[BsonElement("questRewards")]
		[DataMember(Name = "questRewards")]
		public BattleRewardsQuestRewardsData questRewards { get; set; }

		[BsonElement("users")]
		[DataMember(Name = "users")]
		public BattleRewardsUsersData users { get; set; }

	}
}
