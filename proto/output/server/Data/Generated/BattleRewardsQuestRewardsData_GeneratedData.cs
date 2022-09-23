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
	public partial class BattleRewardsQuestRewardsData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("earnedMoney")]
		[DataMember(Name = "earnedMoney")]
		public long earnedMoney { get; set; }

		[BsonElement("earnedExp")]
		[DataMember(Name = "earnedExp")]
		public long earnedExp { get; set; }

		[BsonElement("battleRewardResources")]
		[DataMember(Name = "battleRewardResources")]
		public List<BattleRewardResourceData> battleRewardResources { get; set; } = new List<BattleRewardResourceData>();

	}
}
