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
	public partial class UserSessionData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("sessionId")]
		[DataMember(Name = "sessionId")]
		public string sessionId { get; set; }

		[BsonElement("expireAt")]
		[DataMember(Name = "expireAt")]
		public long expireAt { get; set; }
		[BsonIgnore]
		public DateTime ExpireAt {
			get { return DateTimeUtil.FromEpochTime(expireAt); }
			set { expireAt = value.ToEpochTime(); }
		}

	}
}
