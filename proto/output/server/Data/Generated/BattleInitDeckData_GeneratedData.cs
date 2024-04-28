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
	public partial class BattleInitDeckData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("userUnits")]
		[DataMember(Name = "userUnits")]
		public List<UserUnitData> userUnits { get; set; } = new List<UserUnitData>();

	}
}
