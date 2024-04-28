using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardResourceData : AbstractData
{
	[DataMember(Name = "resource")]
	public ResourceData resource { get; set; }

	[DataMember(Name = "type")]
	public BattleRewardType type { get; set; }

	[DataMember(Name = "param")]
	public long param { get; set; }

	[DataMember(Name = "tag")]
	public string tag { get; set; }

	public BattleRewardResourceData Clone() {
		var result = new BattleRewardResourceData();
		result.resource = resource;
		result.type = type;
		result.param = param;
		result.tag = tag;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
