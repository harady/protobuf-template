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
	public partial class UnitData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("number")]
		[DataMember(Name = "number")]
		public long number { get; set; }

		[BsonElement("baseUnitNumber")]
		[DataMember(Name = "baseUnitNumber")]
		public long baseUnitNumber { get; set; }

		[BsonElement("rarity")]
		[DataMember(Name = "rarity")]
		public long rarity { get; set; }

		[BsonElement("attribute")]
		[DataMember(Name = "attribute")]
		public UnitAttribute attribute { get; set; }

		[BsonElement("attackType")]
		[DataMember(Name = "attackType")]
		public UnitAttackType attackType { get; set; }

		[BsonElement("unitCategoryId")]
		[DataMember(Name = "unitCategoryId")]
		public long unitCategoryId { get; set; }

		[BsonElement("growthType")]
		[DataMember(Name = "growthType")]
		public long growthType { get; set; }

		[BsonElement("maxLevel")]
		[DataMember(Name = "maxLevel")]
		public long maxLevel { get; set; }

		[BsonElement("maxLuck")]
		[DataMember(Name = "maxLuck")]
		public long maxLuck { get; set; }

		[BsonElement("obtainType")]
		[DataMember(Name = "obtainType")]
		public UnitObtainType obtainType { get; set; }

		[BsonElement("baseHp")]
		[DataMember(Name = "baseHp")]
		public long baseHp { get; set; }

		[BsonElement("baseAttack")]
		[DataMember(Name = "baseAttack")]
		public long baseAttack { get; set; }

		[BsonElement("baseSpeed")]
		[DataMember(Name = "baseSpeed")]
		public long baseSpeed { get; set; }

		[BsonElement("maxHp")]
		[DataMember(Name = "maxHp")]
		public long maxHp { get; set; }

		[BsonElement("maxAttack")]
		[DataMember(Name = "maxAttack")]
		public long maxAttack { get; set; }

		[BsonElement("maxSpeed")]
		[DataMember(Name = "maxSpeed")]
		public long maxSpeed { get; set; }

		[BsonElement("maxPlusHp")]
		[DataMember(Name = "maxPlusHp")]
		public long maxPlusHp { get; set; }

		[BsonElement("maxPlusAttack")]
		[DataMember(Name = "maxPlusAttack")]
		public long maxPlusAttack { get; set; }

		[BsonElement("maxPlusSpeed")]
		[DataMember(Name = "maxPlusSpeed")]
		public long maxPlusSpeed { get; set; }

		[BsonElement("skillId")]
		[DataMember(Name = "skillId")]
		public long skillId { get; set; }

		[BsonElement("combo1Id")]
		[DataMember(Name = "combo1Id")]
		public long combo1Id { get; set; }

		[BsonElement("combo2Id")]
		[DataMember(Name = "combo2Id")]
		public long combo2Id { get; set; }

		[BsonElement("ability1Id")]
		[DataMember(Name = "ability1Id")]
		public long ability1Id { get; set; }

		[BsonElement("ability2Id")]
		[DataMember(Name = "ability2Id")]
		public long ability2Id { get; set; }

		[BsonElement("ability3Id")]
		[DataMember(Name = "ability3Id")]
		public long ability3Id { get; set; }

		[BsonElement("ability4Id")]
		[DataMember(Name = "ability4Id")]
		public long ability4Id { get; set; }

		[BsonElement("ability5Id")]
		[DataMember(Name = "ability5Id")]
		public long ability5Id { get; set; }

		[BsonElement("equipmentSlotCount")]
		[DataMember(Name = "equipmentSlotCount")]
		public long equipmentSlotCount { get; set; }

		[BsonElement("salePrice")]
		[DataMember(Name = "salePrice")]
		public long salePrice { get; set; }

		[BsonElement("baseExp")]
		[DataMember(Name = "baseExp")]
		public long baseExp { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
