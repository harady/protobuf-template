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
	public partial class WeakPointPositionData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("weakPointId")]
		[DataMember(Name = "weakPointId")]
		public long weakPointId { get; set; }

		[BsonElement("angle")]
		[DataMember(Name = "angle")]
		public long angle { get; set; }

		[BsonElement("radiusRate")]
		[DataMember(Name = "radiusRate")]
		public long radiusRate { get; set; }

		[BsonElement("sizeRate")]
		[DataMember(Name = "sizeRate")]
		public long sizeRate { get; set; }

	}
}
