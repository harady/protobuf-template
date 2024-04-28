using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultReplayLogData : AbstractData
{
	[DataMember(Name = "time")]
	public float time { get; set; }

	[DataMember(Name = "type")]
	public long type { get; set; }

	[DataMember(Name = "data")]
	public string data { get; set; }

	public BattleResultReplayLogData Clone() {
		var result = new BattleResultReplayLogData();
		result.time = time;
		result.type = type;
		result.data = data;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
