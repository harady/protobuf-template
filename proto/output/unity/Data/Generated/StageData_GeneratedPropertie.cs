using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class StageData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "questId")]
	public long questId { get; set; }

	[DataMember(Name = "stamina")]
	public long stamina { get; set; }

	[DataMember(Name = "earnExp")]
	public long earnExp { get; set; }

	[DataMember(Name = "earnMoney")]
	public long earnMoney { get; set; }

	[DataMember(Name = "questDifficultyType")]
	public QuestDifficultyType questDifficultyType { get; set; }

	[DataMember(Name = "toUnlockStageId")]
	public long toUnlockStageId { get; set; }

	[DataMember(Name = "baseStageId")]
	public long baseStageId { get; set; }

	public StageData Clone() {
		var result = new StageData();
		result.id = id;
		result.name = name;
		result.questId = questId;
		result.stamina = stamina;
		result.earnExp = earnExp;
		result.earnMoney = earnMoney;
		result.questDifficultyType = questDifficultyType;
		result.toUnlockStageId = toUnlockStageId;
		result.baseStageId = baseStageId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
