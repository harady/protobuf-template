using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsUsersData : AbstractData
{
	[DataMember(Name = "hostUsers")]
	public List<OtherUserData> hostUsers { get; set; } = new List<OtherUserData>();

	[DataMember(Name = "guestUsers")]
	public List<OtherUserData> guestUsers { get; set; } = new List<OtherUserData>();

	[DataMember(Name = "helperUsers")]
	public List<OtherUserData> helperUsers { get; set; } = new List<OtherUserData>();

	public BattleRewardsUsersData Clone() {
		var result = new BattleRewardsUsersData();
		result.hostUsers = hostUsers;
		result.guestUsers = guestUsers;
		result.helperUsers = helperUsers;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
