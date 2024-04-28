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
	public partial class EquipmentData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("type")]
		[DataMember(Name = "type")]
		public EquipmentType type { get; set; }

		[BsonElement("description")]
		[DataMember(Name = "description")]
		public string description { get; set; }

		[BsonElement("paramA")]
		[DataMember(Name = "paramA")]
		public long paramA { get; set; }

		[BsonElement("paramB")]
		[DataMember(Name = "paramB")]
		public long paramB { get; set; }

		[BsonElement("iconId")]
		[DataMember(Name = "iconId")]
		public long iconId { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
