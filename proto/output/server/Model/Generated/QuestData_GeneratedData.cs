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
	public partial class QuestData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("questGroupId")]
		[DataMember(Name = "questGroupId")]
		public long questGroupId { get; set; }

		[BsonElement("noContinue")]
		[DataMember(Name = "noContinue")]
		public bool noContinue { get; set; }

		[BsonElement("questDifficultyType")]
		[DataMember(Name = "questDifficultyType")]
		public QuestDifficultyType questDifficultyType { get; set; }

		[BsonElement("bossUnitId")]
		[DataMember(Name = "bossUnitId")]
		public long bossUnitId { get; set; }

		[BsonElement("openAt")]
		[DataMember(Name = "openAt")]
		public long openAt { get; set; }
		[BsonIgnore]
		public DateTime OpenAt {
			get { return DateTimeUtil.FromEpochTime(openAt); }
			set { openAt = value.ToEpochTime(); }
		}

		[BsonElement("closeAt")]
		[DataMember(Name = "closeAt")]
		public long closeAt { get; set; }
		[BsonIgnore]
		public DateTime CloseAt {
			get { return DateTimeUtil.FromEpochTime(closeAt); }
			set { closeAt = value.ToEpochTime(); }
		}

		[BsonElement("openDow")]
		[DataMember(Name = "openDow")]
		public long openDow { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
