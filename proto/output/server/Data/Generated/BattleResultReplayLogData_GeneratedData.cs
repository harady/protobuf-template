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
	public partial class BattleResultReplayLogData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("time")]
		[DataMember(Name = "time")]
		public float time { get; set; }

		[BsonElement("type")]
		[DataMember(Name = "type")]
		public long type { get; set; }

		[BsonElement("data")]
		[DataMember(Name = "data")]
		public string data { get; set; }

	}
}
