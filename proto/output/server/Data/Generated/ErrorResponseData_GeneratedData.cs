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
	public partial class ErrorResponse : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("code")]
		[DataMember(Name = "code")]
		public int code { get; set; }

		[BsonElement("title")]
		[DataMember(Name = "title")]
		public string title { get; set; }

		[BsonElement("message")]
		[DataMember(Name = "message")]
		public string message { get; set; }

		[BsonElement("description")]
		[DataMember(Name = "description")]
		public string description { get; set; }

	}
}
