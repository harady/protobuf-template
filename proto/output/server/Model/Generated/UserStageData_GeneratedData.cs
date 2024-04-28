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
	public partial class UserStageData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("stageId")]
		[DataMember(Name = "stageId")]
		public long stageId { get; set; }

		[BsonElement("clearCount")]
		[DataMember(Name = "clearCount")]
		public long clearCount { get; set; }

		[BsonElement("failedCount")]
		[DataMember(Name = "failedCount")]
		public long failedCount { get; set; }

		[BsonElement("bestClearTime")]
		[DataMember(Name = "bestClearTime")]
		public long bestClearTime { get; set; }

	}
}
