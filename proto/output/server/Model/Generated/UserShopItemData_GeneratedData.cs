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
	public partial class UserShopItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("shopItemId")]
		[DataMember(Name = "shopItemId")]
		public long shopItemId { get; set; }

		[BsonElement("shopScheduleId")]
		[DataMember(Name = "shopScheduleId")]
		public long shopScheduleId { get; set; }

		[BsonElement("purchasedCount")]
		[DataMember(Name = "purchasedCount")]
		public long purchasedCount { get; set; }

	}
}
