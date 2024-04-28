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
	public partial class EventQuestCategoryData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("minStartTime")]
		[DataMember(Name = "minStartTime")]
		public long minStartTime { get; set; }

		[BsonElement("maxStartTime")]
		[DataMember(Name = "maxStartTime")]
		public long maxStartTime { get; set; }

		[BsonElement("openHours")]
		[DataMember(Name = "openHours")]
		public long openHours { get; set; }

		[BsonElement("questGroupId")]
		[DataMember(Name = "questGroupId")]
		public long questGroupId { get; set; }

		[BsonElement("questDifficultyType")]
		[DataMember(Name = "questDifficultyType")]
		public QuestDifficultyType questDifficultyType { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
