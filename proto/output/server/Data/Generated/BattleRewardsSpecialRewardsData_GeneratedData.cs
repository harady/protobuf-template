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
	public partial class BattleRewardsSpecialRewardsData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("battleRewardResources")]
		[DataMember(Name = "battleRewardResources")]
		public List<BattleRewardResourceData> battleRewardResources { get; set; } = new List<BattleRewardResourceData>();

	}
}
