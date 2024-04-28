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
	public partial class CommonRequest : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("sessionId")]
		[DataMember(Name = "sessionId")]
		public string sessionId { get; set; }

	}
}
