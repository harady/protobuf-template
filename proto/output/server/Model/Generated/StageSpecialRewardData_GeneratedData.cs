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
	public partial class StageSpecialRewardData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("stageId")]
		[DataMember(Name = "stageId")]
		public long stageId { get; set; }

		[BsonElement("battleRewardType")]
		[DataMember(Name = "battleRewardType")]
		public BattleRewardType battleRewardType { get; set; }

		[BsonElement("paramA")]
		[DataMember(Name = "paramA")]
		public long paramA { get; set; }

		[BsonElement("paramB")]
		[DataMember(Name = "paramB")]
		public long paramB { get; set; }

		[BsonElement("resourceLotteryId")]
		[DataMember(Name = "resourceLotteryId")]
		public long resourceLotteryId { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
