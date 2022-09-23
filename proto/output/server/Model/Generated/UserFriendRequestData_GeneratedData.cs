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
	public partial class UserFriendRequestData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("senderUserId")]
		[DataMember(Name = "senderUserId")]
		public long senderUserId { get; set; }

		[BsonElement("targetUserId")]
		[DataMember(Name = "targetUserId")]
		public long targetUserId { get; set; }

	}
}
