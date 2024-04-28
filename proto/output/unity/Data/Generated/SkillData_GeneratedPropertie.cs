using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class SkillData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	[DataMember(Name = "turn")]
	public long turn { get; set; }

	[DataMember(Name = "attackRate")]
	public long attackRate { get; set; }

	[DataMember(Name = "speedRate")]
	public long speedRate { get; set; }

	[DataMember(Name = "brakeRate")]
	public long brakeRate { get; set; }

	[DataMember(Name = "effect1Type")]
	public SkillEffectType effect1Type { get; set; }

	[DataMember(Name = "effect1Rank")]
	public long effect1Rank { get; set; }

	[DataMember(Name = "effect1ParamA")]
	public long effect1ParamA { get; set; }

	[DataMember(Name = "effect1ParamB")]
	public long effect1ParamB { get; set; }

	[DataMember(Name = "effect2Type")]
	public SkillEffectType effect2Type { get; set; }

	[DataMember(Name = "effect2Rank")]
	public long effect2Rank { get; set; }

	[DataMember(Name = "effect2ParamA")]
	public long effect2ParamA { get; set; }

	[DataMember(Name = "effect2ParamB")]
	public long effect2ParamB { get; set; }

	public SkillData Clone() {
		var result = new SkillData();
		result.id = id;
		result.name = name;
		result.description = description;
		result.turn = turn;
		result.attackRate = attackRate;
		result.speedRate = speedRate;
		result.brakeRate = brakeRate;
		result.effect1Type = effect1Type;
		result.effect1Rank = effect1Rank;
		result.effect1ParamA = effect1ParamA;
		result.effect1ParamB = effect1ParamB;
		result.effect2Type = effect2Type;
		result.effect2Rank = effect2Rank;
		result.effect2ParamA = effect2ParamA;
		result.effect2ParamB = effect2ParamB;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
