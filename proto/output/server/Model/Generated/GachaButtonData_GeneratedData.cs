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
	public partial class GachaButtonData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("gachaId")]
		[DataMember(Name = "gachaId")]
		public long gachaId { get; set; }

		[BsonElement("viewOrder")]
		[DataMember(Name = "viewOrder")]
		public long viewOrder { get; set; }

		[BsonElement("drawCount")]
		[DataMember(Name = "drawCount")]
		public long drawCount { get; set; }

		[BsonElement("extraCount")]
		[DataMember(Name = "extraCount")]
		public long extraCount { get; set; }

		[BsonElement("guaranteeCount")]
		[DataMember(Name = "guaranteeCount")]
		public long guaranteeCount { get; set; }

		[BsonElement("purchaseCount")]
		[DataMember(Name = "purchaseCount")]
		public long purchaseCount { get; set; }

		[BsonElement("costResourceType")]
		[DataMember(Name = "costResourceType")]
		public ResourceType costResourceType { get; set; }

		[BsonElement("costResourceId")]
		[DataMember(Name = "costResourceId")]
		public long costResourceId { get; set; }

		[BsonElement("costResourceAmount")]
		[DataMember(Name = "costResourceAmount")]
		public long costResourceAmount { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
