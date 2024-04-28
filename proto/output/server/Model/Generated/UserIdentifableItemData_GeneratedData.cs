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
	public partial class UserIdentifableItemData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("identifableItemId")]
		[DataMember(Name = "identifableItemId")]
		public long identifableItemId { get; set; }

		[BsonElement("paramA")]
		[DataMember(Name = "paramA")]
		public long paramA { get; set; }

		[BsonElement("paramB")]
		[DataMember(Name = "paramB")]
		public long paramB { get; set; }

	}
}
