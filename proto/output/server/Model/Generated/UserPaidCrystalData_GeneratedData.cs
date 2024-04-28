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
	public partial class UserPaidCrystalData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("purchasePlatformType")]
		[DataMember(Name = "purchasePlatformType")]
		public PurchasePlatformType purchasePlatformType { get; set; }

		[BsonElement("amount")]
		[DataMember(Name = "amount")]
		public long amount { get; set; }

	}
}
