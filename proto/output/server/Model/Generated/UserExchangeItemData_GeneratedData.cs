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
	public partial class UserExchangeItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("exchangeItemId")]
		[DataMember(Name = "exchangeItemId")]
		public long exchangeItemId { get; set; }

		[BsonElement("exchangeScheduleId")]
		[DataMember(Name = "exchangeScheduleId")]
		public long exchangeScheduleId { get; set; }

		[BsonElement("exchangedCount")]
		[DataMember(Name = "exchangedCount")]
		public long exchangedCount { get; set; }

	}
}
