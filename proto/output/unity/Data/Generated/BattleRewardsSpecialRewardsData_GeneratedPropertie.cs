using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsSpecialRewardsData : AbstractData
{
	[DataMember(Name = "battleRewardResources")]
	public List<BattleRewardResourceData> battleRewardResources { get; set; } = new List<BattleRewardResourceData>();

	public BattleRewardsSpecialRewardsData Clone() {
		var result = new BattleRewardsSpecialRewardsData();
		result.battleRewardResources = battleRewardResources;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
