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
	public partial class BattleRewardResourceData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("resource")]
		[DataMember(Name = "resource")]
		public ResourceData resource { get; set; }

		[BsonElement("type")]
		[DataMember(Name = "type")]
		public BattleRewardType type { get; set; }

		[BsonElement("param")]
		[DataMember(Name = "param")]
		public long param { get; set; }

		[BsonElement("tag")]
		[DataMember(Name = "tag")]
		public string tag { get; set; }

	}
}
