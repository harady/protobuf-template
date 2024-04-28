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
	public partial class BattleRewardsUsersData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("hostUsers")]
		[DataMember(Name = "hostUsers")]
		public List<OtherUserData> hostUsers { get; set; } = new List<OtherUserData>();

		[BsonElement("guestUsers")]
		[DataMember(Name = "guestUsers")]
		public List<OtherUserData> guestUsers { get; set; } = new List<OtherUserData>();

		[BsonElement("helperUsers")]
		[DataMember(Name = "helperUsers")]
		public List<OtherUserData> helperUsers { get; set; } = new List<OtherUserData>();

	}
}
