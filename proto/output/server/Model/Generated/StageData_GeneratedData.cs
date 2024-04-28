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
	public partial class StageData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("questId")]
		[DataMember(Name = "questId")]
		public long questId { get; set; }

		[BsonElement("stamina")]
		[DataMember(Name = "stamina")]
		public long stamina { get; set; }

		[BsonElement("earnExp")]
		[DataMember(Name = "earnExp")]
		public long earnExp { get; set; }

		[BsonElement("earnMoney")]
		[DataMember(Name = "earnMoney")]
		public long earnMoney { get; set; }

		[BsonElement("questDifficultyType")]
		[DataMember(Name = "questDifficultyType")]
		public QuestDifficultyType questDifficultyType { get; set; }

		[BsonElement("toUnlockStageId")]
		[DataMember(Name = "toUnlockStageId")]
		public long toUnlockStageId { get; set; }

		[BsonElement("baseStageId")]
		[DataMember(Name = "baseStageId")]
		public long baseStageId { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
