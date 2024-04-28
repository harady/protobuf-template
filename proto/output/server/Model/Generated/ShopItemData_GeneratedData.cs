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
	public partial class ShopItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("shopId")]
		[DataMember(Name = "shopId")]
		public long shopId { get; set; }

		[BsonElement("purchasePlatformType")]
		[DataMember(Name = "purchasePlatformType")]
		public PurchasePlatformType purchasePlatformType { get; set; }

		[BsonElement("platformProductId")]
		[DataMember(Name = "platformProductId")]
		public string platformProductId { get; set; }

		[BsonElement("price")]
		[DataMember(Name = "price")]
		public long price { get; set; }

		[BsonElement("resourceSetId")]
		[DataMember(Name = "resourceSetId")]
		public long resourceSetId { get; set; }

		[BsonElement("limitCount")]
		[DataMember(Name = "limitCount")]
		public long limitCount { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
