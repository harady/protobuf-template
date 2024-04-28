using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class StageSpecialRewardData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "battleRewardType")]
	public BattleRewardType battleRewardType { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	[DataMember(Name = "resourceLotteryId")]
	public long resourceLotteryId { get; set; }

	public StageSpecialRewardData Clone() {
		var result = new StageSpecialRewardData();
		result.id = id;
		result.name = name;
		result.stageId = stageId;
		result.battleRewardType = battleRewardType;
		result.paramA = paramA;
		result.paramB = paramB;
		result.resourceLotteryId = resourceLotteryId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
