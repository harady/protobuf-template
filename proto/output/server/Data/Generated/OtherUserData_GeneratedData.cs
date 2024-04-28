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
	public partial class OtherUserData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("code")]
		[DataMember(Name = "code")]
		public long code { get; set; }

		[BsonElement("rank")]
		[DataMember(Name = "rank")]
		public long rank { get; set; }

		[BsonElement("userUnit")]
		[DataMember(Name = "userUnit")]
		public UserUnitData userUnit { get; set; }

		[BsonElement("isFriend")]
		[DataMember(Name = "isFriend")]
		public bool isFriend { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
