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
	public partial class ResourceSetItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("resourceSetId")]
		[DataMember(Name = "resourceSetId")]
		public long resourceSetId { get; set; }

		[BsonElement("resourceType")]
		[DataMember(Name = "resourceType")]
		public ResourceType resourceType { get; set; }

		[BsonElement("resourceId")]
		[DataMember(Name = "resourceId")]
		public long resourceId { get; set; }

		[BsonElement("resourceAmount")]
		[DataMember(Name = "resourceAmount")]
		public long resourceAmount { get; set; }

	}
}
