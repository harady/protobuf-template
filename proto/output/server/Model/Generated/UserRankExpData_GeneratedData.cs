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
	public partial class UserRankExpData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("rank")]
		[DataMember(Name = "rank")]
		public long rank { get; set; }

		[BsonElement("totalExp")]
		[DataMember(Name = "totalExp")]
		public long totalExp { get; set; }

		[BsonElement("maxStamina")]
		[DataMember(Name = "maxStamina")]
		public long maxStamina { get; set; }

		[BsonElement("deckNum")]
		[DataMember(Name = "deckNum")]
		public long deckNum { get; set; }

		[BsonElement("maxFriendNum")]
		[DataMember(Name = "maxFriendNum")]
		public long maxFriendNum { get; set; }

		[BsonElement("unitBoxNum")]
		[DataMember(Name = "unitBoxNum")]
		public long unitBoxNum { get; set; }

	}
}
