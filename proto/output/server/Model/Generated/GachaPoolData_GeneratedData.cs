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
	public partial class GachaPoolData : AbstractData
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

		[BsonElement("baseGachaPoolId")]
		[DataMember(Name = "baseGachaPoolId")]
		public long baseGachaPoolId { get; set; }

		[BsonElement("isExtra")]
		[DataMember(Name = "isExtra")]
		public bool isExtra { get; set; }

		[BsonElement("isPickup")]
		[DataMember(Name = "isPickup")]
		public bool isPickup { get; set; }

		[BsonElement("isGuarantee")]
		[DataMember(Name = "isGuarantee")]
		public bool isGuarantee { get; set; }

		[BsonElement("rarity")]
		[DataMember(Name = "rarity")]
		public long rarity { get; set; }

		[BsonElement("attribute")]
		[DataMember(Name = "attribute")]
		public UnitAttribute attribute { get; set; }

		[BsonElement("weight")]
		[DataMember(Name = "weight")]
		public long weight { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
