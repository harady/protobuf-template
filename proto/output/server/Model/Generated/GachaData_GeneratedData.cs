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
	public partial class GachaData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("baseGachaId")]
		[DataMember(Name = "baseGachaId")]
		public long baseGachaId { get; set; }

		[BsonElement("isPremium")]
		[DataMember(Name = "isPremium")]
		public bool isPremium { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
