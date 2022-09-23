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
	public partial class BattleInitEnemyData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("roundId")]
		[DataMember(Name = "roundId")]
		public long roundId { get; set; }

		[BsonElement("enemyId")]
		[DataMember(Name = "enemyId")]
		public long enemyId { get; set; }

		[BsonElement("posX")]
		[DataMember(Name = "posX")]
		public long posX { get; set; }

		[BsonElement("posY")]
		[DataMember(Name = "posY")]
		public long posY { get; set; }

		[BsonElement("dropRewardResource")]
		[DataMember(Name = "dropRewardResource")]
		public ResourceData dropRewardResource { get; set; }

	}
}
