using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "turnLogs")]
	public List<BattleResultTurnLogData> turnLogs { get; set; } = new List<BattleResultTurnLogData>();

	[DataMember(Name = "replayLogs")]
	public List<BattleResultReplayLogData> replayLogs { get; set; } = new List<BattleResultReplayLogData>();

	public BattleResultData Clone() {
		var result = new BattleResultData();
		result.id = id;
		result.turnLogs = turnLogs;
		result.replayLogs = replayLogs;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
