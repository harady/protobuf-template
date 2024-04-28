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
	public partial class UserDeckData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("deckNo")]
		[DataMember(Name = "deckNo")]
		public long deckNo { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("userUnit1Id")]
		[DataMember(Name = "userUnit1Id")]
		public long userUnit1Id { get; set; }

		[BsonElement("userUnit2Id")]
		[DataMember(Name = "userUnit2Id")]
		public long userUnit2Id { get; set; }

		[BsonElement("userUnit3Id")]
		[DataMember(Name = "userUnit3Id")]
		public long userUnit3Id { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
