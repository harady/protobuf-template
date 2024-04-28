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
	public partial class EnemyData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("unitId")]
		[DataMember(Name = "unitId")]
		public long unitId { get; set; }

		[BsonElement("hp")]
		[DataMember(Name = "hp")]
		public long hp { get; set; }

		[BsonElement("size")]
		[DataMember(Name = "size")]
		public long size { get; set; }

		[BsonElement("weakPointId")]
		[DataMember(Name = "weakPointId")]
		public long weakPointId { get; set; }

		[BsonElement("isBoss")]
		[DataMember(Name = "isBoss")]
		public bool isBoss { get; set; }

		[BsonElement("isEscape")]
		[DataMember(Name = "isEscape")]
		public bool isEscape { get; set; }

		[BsonElement("damageRate")]
		[DataMember(Name = "damageRate")]
		public long damageRate { get; set; }

		[BsonElement("directDamageRate")]
		[DataMember(Name = "directDamageRate")]
		public long directDamageRate { get; set; }

		[BsonElement("indirectDamageRate")]
		[DataMember(Name = "indirectDamageRate")]
		public long indirectDamageRate { get; set; }

		[BsonElement("baseEnemyId")]
		[DataMember(Name = "baseEnemyId")]
		public long baseEnemyId { get; set; }

		[BsonElement("dropRate")]
		[DataMember(Name = "dropRate")]
		public long dropRate { get; set; }

		[BsonElement("rewardResourceLotteryId")]
		[DataMember(Name = "rewardResourceLotteryId")]
		public long rewardResourceLotteryId { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
