using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsData : AbstractData
{
	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "specialRewards")]
	public BattleRewardsSpecialRewardsData specialRewards { get; set; }

	[DataMember(Name = "questRewards")]
	public BattleRewardsQuestRewardsData questRewards { get; set; }

	[DataMember(Name = "users")]
	public BattleRewardsUsersData users { get; set; }

	public BattleRewardsData Clone() {
		var result = new BattleRewardsData();
		result.stageId = stageId;
		result.specialRewards = specialRewards;
		result.questRewards = questRewards;
		result.users = users;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
