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
	public partial class UserFriendData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("friendUserId")]
		[DataMember(Name = "friendUserId")]
		public long friendUserId { get; set; }

		[BsonElement("isFavorite")]
		[DataMember(Name = "isFavorite")]
		public bool isFavorite { get; set; }

		[BsonElement("lastUsedAt")]
		[DataMember(Name = "lastUsedAt")]
		public long lastUsedAt { get; set; }
		[BsonIgnore]
		public DateTime LastUsedAt {
			get { return DateTimeUtil.FromEpochTime(lastUsedAt); }
			set { lastUsedAt = value.ToEpochTime(); }
		}

		[BsonElement("usedCount")]
		[DataMember(Name = "usedCount")]
		public long usedCount { get; set; }

	}
}
