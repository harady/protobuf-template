using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserBattleData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "continueCount")]
	public long continueCount { get; set; }

	[DataMember(Name = "battleClientData")]
	public BattleClientData battleClientData { get; set; }

	[DataMember(Name = "battleServerData")]
	public BattleServerData battleServerData { get; set; }

	[DataMember(Name = "startAt")]
	public long startAt { get; set; }

	public DateTime StartAt {
		get { return ServerDateTimeUtil.FromEpoch(startAt); }
		set { startAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	public UserBattleData Clone() {
		var result = new UserBattleData();
		result.id = id;
		result.userId = userId;
		result.stageId = stageId;
		result.continueCount = continueCount;
		result.battleClientData = battleClientData;
		result.battleServerData = battleServerData;
		result.startAt = startAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
