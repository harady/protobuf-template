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
	public partial class UserUnitData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("unitId")]
		[DataMember(Name = "unitId")]
		public long unitId { get; set; }

		[BsonElement("level")]
		[DataMember(Name = "level")]
		public long level { get; set; }

		[BsonElement("exp")]
		[DataMember(Name = "exp")]
		public long exp { get; set; }

		[BsonElement("luck")]
		[DataMember(Name = "luck")]
		public long luck { get; set; }

		[BsonElement("plusHp")]
		[DataMember(Name = "plusHp")]
		public long plusHp { get; set; }

		[BsonElement("plusAttack")]
		[DataMember(Name = "plusAttack")]
		public long plusAttack { get; set; }

		[BsonElement("plusSpeed")]
		[DataMember(Name = "plusSpeed")]
		public long plusSpeed { get; set; }

		[BsonElement("equipment1Id")]
		[DataMember(Name = "equipment1Id")]
		public long equipment1Id { get; set; }

		[BsonElement("equipment2Id")]
		[DataMember(Name = "equipment2Id")]
		public long equipment2Id { get; set; }

		[BsonElement("equipment3Id")]
		[DataMember(Name = "equipment3Id")]
		public long equipment3Id { get; set; }

		[BsonElement("heroMark")]
		[DataMember(Name = "heroMark")]
		public bool heroMark { get; set; }

		[BsonElement("heroBadge")]
		[DataMember(Name = "heroBadge")]
		public bool heroBadge { get; set; }

		[BsonElement("isLocked")]
		[DataMember(Name = "isLocked")]
		public bool isLocked { get; set; }

		[BsonElement("getAt")]
		[DataMember(Name = "getAt")]
		public long getAt { get; set; }
		[BsonIgnore]
		public DateTime GetAt {
			get { return DateTimeUtil.FromEpochTime(getAt); }
			set { getAt = value.ToEpochTime(); }
		}

	}
}
