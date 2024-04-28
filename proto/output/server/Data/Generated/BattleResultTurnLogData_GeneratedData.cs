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
	public partial class BattleResultTurnLogData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("turnNo")]
		[DataMember(Name = "turnNo")]
		public long turnNo { get; set; }

		[BsonElement("roundNo")]
		[DataMember(Name = "roundNo")]
		public long roundNo { get; set; }

		[BsonElement("hitCount")]
		[DataMember(Name = "hitCount")]
		public long hitCount { get; set; }

		[BsonElement("totalDamage")]
		[DataMember(Name = "totalDamage")]
		public long totalDamage { get; set; }

		[BsonElement("killedEnemyMappingIds")]
		[DataMember(Name = "killedEnemyMappingIds")]
		public List<long> killedEnemyMappingIds { get; set; } = new List<long>();

		[BsonElement("totalWaitingTime")]
		[DataMember(Name = "totalWaitingTime")]
		public float totalWaitingTime { get; set; }

		[BsonElement("turnEndTime")]
		[DataMember(Name = "turnEndTime")]
		public float turnEndTime { get; set; }

		[BsonElement("turnEndRealtime")]
		[DataMember(Name = "turnEndRealtime")]
		public float turnEndRealtime { get; set; }

		[BsonElement("isShot")]
		[DataMember(Name = "isShot")]
		public bool isShot { get; set; }

		[BsonElement("isUseSkill")]
		[DataMember(Name = "isUseSkill")]
		public bool isUseSkill { get; set; }

		[BsonElement("shotAngle")]
		[DataMember(Name = "shotAngle")]
		public float shotAngle { get; set; }

		[BsonElement("hash")]
		[DataMember(Name = "hash")]
		public string hash { get; set; }

	}
}
