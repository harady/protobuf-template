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
	public partial class SkillData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("description")]
		[DataMember(Name = "description")]
		public string description { get; set; }

		[BsonElement("turn")]
		[DataMember(Name = "turn")]
		public long turn { get; set; }

		[BsonElement("attackRate")]
		[DataMember(Name = "attackRate")]
		public long attackRate { get; set; }

		[BsonElement("speedRate")]
		[DataMember(Name = "speedRate")]
		public long speedRate { get; set; }

		[BsonElement("brakeRate")]
		[DataMember(Name = "brakeRate")]
		public long brakeRate { get; set; }

		[BsonElement("effect1Type")]
		[DataMember(Name = "effect1Type")]
		public SkillEffectType effect1Type { get; set; }

		[BsonElement("effect1Rank")]
		[DataMember(Name = "effect1Rank")]
		public long effect1Rank { get; set; }

		[BsonElement("effect1ParamA")]
		[DataMember(Name = "effect1ParamA")]
		public long effect1ParamA { get; set; }

		[BsonElement("effect1ParamB")]
		[DataMember(Name = "effect1ParamB")]
		public long effect1ParamB { get; set; }

		[BsonElement("effect2Type")]
		[DataMember(Name = "effect2Type")]
		public SkillEffectType effect2Type { get; set; }

		[BsonElement("effect2Rank")]
		[DataMember(Name = "effect2Rank")]
		public long effect2Rank { get; set; }

		[BsonElement("effect2ParamA")]
		[DataMember(Name = "effect2ParamA")]
		public long effect2ParamA { get; set; }

		[BsonElement("effect2ParamB")]
		[DataMember(Name = "effect2ParamB")]
		public long effect2ParamB { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
