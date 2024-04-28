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
	public partial class GachaResultItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("resource")]
		[DataMember(Name = "resource")]
		public ResourceData resource { get; set; }

		[BsonElement("isExtra")]
		[DataMember(Name = "isExtra")]
		public bool isExtra { get; set; }

		[BsonElement("isPickup")]
		[DataMember(Name = "isPickup")]
		public bool isPickup { get; set; }

		[BsonElement("isGuarantee")]
		[DataMember(Name = "isGuarantee")]
		public bool isGuarantee { get; set; }

	}
}
