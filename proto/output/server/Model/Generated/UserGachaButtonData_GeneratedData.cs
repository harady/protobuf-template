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
	public partial class UserGachaButtonData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("gachaButtonId")]
		[DataMember(Name = "gachaButtonId")]
		public long gachaButtonId { get; set; }

		[BsonElement("gachaScheduleId")]
		[DataMember(Name = "gachaScheduleId")]
		public long gachaScheduleId { get; set; }

		[BsonElement("purchaseCount")]
		[DataMember(Name = "purchaseCount")]
		public long purchaseCount { get; set; }

	}
}
