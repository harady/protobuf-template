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
	public partial class UserUnitCollectionData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("unitId")]
		[DataMember(Name = "unitId")]
		public long unitId { get; set; }

		[BsonElement("hasEarned")]
		[DataMember(Name = "hasEarned")]
		public bool hasEarned { get; set; }

		[BsonElement("usedCount")]
		[DataMember(Name = "usedCount")]
		public long usedCount { get; set; }

	}
}
