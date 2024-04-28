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
	public partial class ResourceLotteryItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("resourceLotteryId")]
		[DataMember(Name = "resourceLotteryId")]
		public long resourceLotteryId { get; set; }

		[BsonElement("weight")]
		[DataMember(Name = "weight")]
		public long weight { get; set; }

		[BsonElement("resourceType")]
		[DataMember(Name = "resourceType")]
		public ResourceType resourceType { get; set; }

		[BsonElement("resourceId")]
		[DataMember(Name = "resourceId")]
		public long resourceId { get; set; }

		[BsonElement("resourceAmountMin")]
		[DataMember(Name = "resourceAmountMin")]
		public long resourceAmountMin { get; set; }

		[BsonElement("resourceAmountMax")]
		[DataMember(Name = "resourceAmountMax")]
		public long resourceAmountMax { get; set; }

	}
}
