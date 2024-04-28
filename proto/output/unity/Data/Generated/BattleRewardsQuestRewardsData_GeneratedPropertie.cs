using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsQuestRewardsData : AbstractData
{
	[DataMember(Name = "earnedMoney")]
	public long earnedMoney { get; set; }

	[DataMember(Name = "earnedExp")]
	public long earnedExp { get; set; }

	[DataMember(Name = "battleRewardResources")]
	public List<BattleRewardResourceData> battleRewardResources { get; set; } = new List<BattleRewardResourceData>();

	public BattleRewardsQuestRewardsData Clone() {
		var result = new BattleRewardsQuestRewardsData();
		result.earnedMoney = earnedMoney;
		result.earnedExp = earnedExp;
		result.battleRewardResources = battleRewardResources;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
