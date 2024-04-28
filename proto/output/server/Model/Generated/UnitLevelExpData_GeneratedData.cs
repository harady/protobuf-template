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
	public partial class UnitLevelExpData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("growthType")]
		[DataMember(Name = "growthType")]
		public long growthType { get; set; }

		[BsonElement("level")]
		[DataMember(Name = "level")]
		public long level { get; set; }

		[BsonElement("totalExp")]
		[DataMember(Name = "totalExp")]
		public long totalExp { get; set; }

	}
}
