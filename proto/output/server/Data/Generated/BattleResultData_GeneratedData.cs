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
	public partial class BattleResultData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("turnLogs")]
		[DataMember(Name = "turnLogs")]
		public List<BattleResultTurnLogData> turnLogs { get; set; } = new List<BattleResultTurnLogData>();

		[BsonElement("replayLogs")]
		[DataMember(Name = "replayLogs")]
		public List<BattleResultReplayLogData> replayLogs { get; set; } = new List<BattleResultReplayLogData>();

	}
}
