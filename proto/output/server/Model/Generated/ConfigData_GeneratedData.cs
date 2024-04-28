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
	public partial class ConfigData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("key")]
		[DataMember(Name = "key")]
		public string key { get; set; }

		[BsonElement("value")]
		[DataMember(Name = "value")]
		public long value { get; set; }

		[BsonElement("text")]
		[DataMember(Name = "text")]
		public string text { get; set; }

	}
}
