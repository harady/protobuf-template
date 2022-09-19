using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class QuestData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "questGroupId")]
	public long questGroupId { get; set; }

	[DataMember(Name = "nocontinue")]
	public bool nocontinue { get; set; }

	[DataMember(Name = "questDifficultyType")]
	public QuestDifficultyType questDifficultyType { get; set; }

	[DataMember(Name = "bossUnitId")]
	public long bossUnitId { get; set; }

	[DataMember(Name = "openAt")]
	public long openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public long closeAt { get; set; }

	[DataMember(Name = "openDow")]
	public long openDow { get; set; }

	public AbilityData Clone() {
		var result = new QuestData();
		result.id = id;
		result.name = name;
		result.questGroupId = questGroupId;
		result.nocontinue = nocontinue;
		result.questDifficultyType = questDifficultyType;
		result.bossUnitId = bossUnitId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		result.openDow = openDow;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
