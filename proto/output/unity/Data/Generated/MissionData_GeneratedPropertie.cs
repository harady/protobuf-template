using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MissionData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "missionGroupId")]
	public long missionGroupId { get; set; }

	[DataMember(Name = "type")]
	public MissionType type { get; set; }

	[DataMember(Name = "toAchieveProgress")]
	public long toAchieveProgress { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	[DataMember(Name = "rewardResourceType")]
	public ResourceType rewardResourceType { get; set; }

	[DataMember(Name = "rewardResourceId")]
	public long rewardResourceId { get; set; }

	[DataMember(Name = "rewardResourceAmount")]
	public long rewardResourceAmount { get; set; }

	public MissionData Clone() {
		var result = new MissionData();
		result.id = id;
		result.name = name;
		result.missionGroupId = missionGroupId;
		result.type = type;
		result.toAchieveProgress = toAchieveProgress;
		result.paramA = paramA;
		result.paramB = paramB;
		result.rewardResourceType = rewardResourceType;
		result.rewardResourceId = rewardResourceId;
		result.rewardResourceAmount = rewardResourceAmount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
