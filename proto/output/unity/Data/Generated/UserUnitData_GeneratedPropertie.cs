using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUnitData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "unitId")]
	public long unitId { get; set; }

	[DataMember(Name = "level")]
	public long level { get; set; }

	[DataMember(Name = "exp")]
	public long exp { get; set; }

	[DataMember(Name = "luck")]
	public long luck { get; set; }

	[DataMember(Name = "plusHp")]
	public long plusHp { get; set; }

	[DataMember(Name = "plusAttack")]
	public long plusAttack { get; set; }

	[DataMember(Name = "plusSpeed")]
	public long plusSpeed { get; set; }

	[DataMember(Name = "equipment1Id")]
	public long equipment1Id { get; set; }

	[DataMember(Name = "equipment2Id")]
	public long equipment2Id { get; set; }

	[DataMember(Name = "equipment3Id")]
	public long equipment3Id { get; set; }

	[DataMember(Name = "heroMark")]
	public bool heroMark { get; set; }

	[DataMember(Name = "heroBadge")]
	public bool heroBadge { get; set; }

	[DataMember(Name = "isLocked")]
	public bool isLocked { get; set; }

	[DataMember(Name = "getAt")]
	public long getAt { get; set; }

	public DateTime GetAt {
		get { return ServerDateTimeUtil.FromEpoch(getAt); }
		set { getAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	public UserUnitData Clone() {
		var result = new UserUnitData();
		result.id = id;
		result.userId = userId;
		result.unitId = unitId;
		result.level = level;
		result.exp = exp;
		result.luck = luck;
		result.plusHp = plusHp;
		result.plusAttack = plusAttack;
		result.plusSpeed = plusSpeed;
		result.equipment1Id = equipment1Id;
		result.equipment2Id = equipment2Id;
		result.equipment3Id = equipment3Id;
		result.heroMark = heroMark;
		result.heroBadge = heroBadge;
		result.isLocked = isLocked;
		result.getAt = getAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
