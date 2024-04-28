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
	public partial class BattleUserData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("otherUser")]
		[DataMember(Name = "otherUser")]
		public OtherUserData otherUser { get; set; }

		[BsonElement("userUnitIds")]
		[DataMember(Name = "userUnitIds")]
		public List<long> userUnitIds { get; set; } = new List<long>();

	}
}
