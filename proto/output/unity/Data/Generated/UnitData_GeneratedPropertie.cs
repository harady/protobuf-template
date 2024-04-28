using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "number")]
	public long number { get; set; }

	[DataMember(Name = "baseUnitNumber")]
	public long baseUnitNumber { get; set; }

	[DataMember(Name = "rarity")]
	public long rarity { get; set; }

	[DataMember(Name = "attribute")]
	public UnitAttribute attribute { get; set; }

	[DataMember(Name = "attackType")]
	public UnitAttackType attackType { get; set; }

	[DataMember(Name = "unitCategoryId")]
	public long unitCategoryId { get; set; }

	[DataMember(Name = "growthType")]
	public long growthType { get; set; }

	[DataMember(Name = "maxLevel")]
	public long maxLevel { get; set; }

	[DataMember(Name = "maxLuck")]
	public long maxLuck { get; set; }

	[DataMember(Name = "obtainType")]
	public UnitObtainType obtainType { get; set; }

	[DataMember(Name = "baseHp")]
	public long baseHp { get; set; }

	[DataMember(Name = "baseAttack")]
	public long baseAttack { get; set; }

	[DataMember(Name = "baseSpeed")]
	public long baseSpeed { get; set; }

	[DataMember(Name = "maxHp")]
	public long maxHp { get; set; }

	[DataMember(Name = "maxAttack")]
	public long maxAttack { get; set; }

	[DataMember(Name = "maxSpeed")]
	public long maxSpeed { get; set; }

	[DataMember(Name = "maxPlusHp")]
	public long maxPlusHp { get; set; }

	[DataMember(Name = "maxPlusAttack")]
	public long maxPlusAttack { get; set; }

	[DataMember(Name = "maxPlusSpeed")]
	public long maxPlusSpeed { get; set; }

	[DataMember(Name = "skillId")]
	public long skillId { get; set; }

	[DataMember(Name = "combo1Id")]
	public long combo1Id { get; set; }

	[DataMember(Name = "combo2Id")]
	public long combo2Id { get; set; }

	[DataMember(Name = "ability1Id")]
	public long ability1Id { get; set; }

	[DataMember(Name = "ability2Id")]
	public long ability2Id { get; set; }

	[DataMember(Name = "ability3Id")]
	public long ability3Id { get; set; }

	[DataMember(Name = "ability4Id")]
	public long ability4Id { get; set; }

	[DataMember(Name = "ability5Id")]
	public long ability5Id { get; set; }

	[DataMember(Name = "equipmentSlotCount")]
	public long equipmentSlotCount { get; set; }

	[DataMember(Name = "salePrice")]
	public long salePrice { get; set; }

	[DataMember(Name = "baseExp")]
	public long baseExp { get; set; }

	public UnitData Clone() {
		var result = new UnitData();
		result.id = id;
		result.name = name;
		result.number = number;
		result.baseUnitNumber = baseUnitNumber;
		result.rarity = rarity;
		result.attribute = attribute;
		result.attackType = attackType;
		result.unitCategoryId = unitCategoryId;
		result.growthType = growthType;
		result.maxLevel = maxLevel;
		result.maxLuck = maxLuck;
		result.obtainType = obtainType;
		result.baseHp = baseHp;
		result.baseAttack = baseAttack;
		result.baseSpeed = baseSpeed;
		result.maxHp = maxHp;
		result.maxAttack = maxAttack;
		result.maxSpeed = maxSpeed;
		result.maxPlusHp = maxPlusHp;
		result.maxPlusAttack = maxPlusAttack;
		result.maxPlusSpeed = maxPlusSpeed;
		result.skillId = skillId;
		result.combo1Id = combo1Id;
		result.combo2Id = combo2Id;
		result.ability1Id = ability1Id;
		result.ability2Id = ability2Id;
		result.ability3Id = ability3Id;
		result.ability4Id = ability4Id;
		result.ability5Id = ability5Id;
		result.equipmentSlotCount = equipmentSlotCount;
		result.salePrice = salePrice;
		result.baseExp = baseExp;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
