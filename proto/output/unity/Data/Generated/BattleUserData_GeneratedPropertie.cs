using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleUserData : AbstractData
{
	[DataMember(Name = "otherUser")]
	public OtherUserData otherUser { get; set; }

	[DataMember(Name = "userUnitIds")]
	public List<long> userUnitIds { get; set; } = new List<long>();

	public BattleUserData Clone() {
		var result = new BattleUserData();
		result.otherUser = otherUser;
		result.userUnitIds = userUnitIds;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
