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
	public partial class ExchangeItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("exchangeId")]
		[DataMember(Name = "exchangeId")]
		public long exchangeId { get; set; }

		[BsonElement("costResourceType")]
		[DataMember(Name = "costResourceType")]
		public ResourceType costResourceType { get; set; }

		[BsonElement("costResourceId")]
		[DataMember(Name = "costResourceId")]
		public long costResourceId { get; set; }

		[BsonElement("costResourceAmount")]
		[DataMember(Name = "costResourceAmount")]
		public long costResourceAmount { get; set; }

		[BsonElement("resourceType")]
		[DataMember(Name = "resourceType")]
		public ResourceType resourceType { get; set; }

		[BsonElement("resourceId")]
		[DataMember(Name = "resourceId")]
		public long resourceId { get; set; }

		[BsonElement("resourceAmount")]
		[DataMember(Name = "resourceAmount")]
		public long resourceAmount { get; set; }

		[BsonElement("resourceSetId")]
		[DataMember(Name = "resourceSetId")]
		public long resourceSetId { get; set; }

		[BsonElement("limitCount")]
		[DataMember(Name = "limitCount")]
		public long limitCount { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
