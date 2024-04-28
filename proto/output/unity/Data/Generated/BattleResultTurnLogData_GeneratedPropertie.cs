using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultTurnLogData : AbstractData
{
	[DataMember(Name = "turnNo")]
	public long turnNo { get; set; }

	[DataMember(Name = "roundNo")]
	public long roundNo { get; set; }

	[DataMember(Name = "hitCount")]
	public long hitCount { get; set; }

	[DataMember(Name = "totalDamage")]
	public long totalDamage { get; set; }

	[DataMember(Name = "killedEnemyMappingIds")]
	public List<long> killedEnemyMappingIds { get; set; } = new List<long>();

	[DataMember(Name = "totalWaitingTime")]
	public float totalWaitingTime { get; set; }

	[DataMember(Name = "turnEndTime")]
	public float turnEndTime { get; set; }

	[DataMember(Name = "turnEndRealtime")]
	public float turnEndRealtime { get; set; }

	[DataMember(Name = "isShot")]
	public bool isShot { get; set; }

	[DataMember(Name = "isUseSkill")]
	public bool isUseSkill { get; set; }

	[DataMember(Name = "shotAngle")]
	public float shotAngle { get; set; }

	[DataMember(Name = "hash")]
	public string hash { get; set; }

	public BattleResultTurnLogData Clone() {
		var result = new BattleResultTurnLogData();
		result.turnNo = turnNo;
		result.roundNo = roundNo;
		result.hitCount = hitCount;
		result.totalDamage = totalDamage;
		result.killedEnemyMappingIds = killedEnemyMappingIds;
		result.totalWaitingTime = totalWaitingTime;
		result.turnEndTime = turnEndTime;
		result.turnEndRealtime = turnEndRealtime;
		result.isShot = isShot;
		result.isUseSkill = isUseSkill;
		result.shotAngle = shotAngle;
		result.hash = hash;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
