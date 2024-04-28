using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleInitEnemyData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "roundId")]
	public long roundId { get; set; }

	[DataMember(Name = "enemyId")]
	public long enemyId { get; set; }

	[DataMember(Name = "posX")]
	public long posX { get; set; }

	[DataMember(Name = "posY")]
	public long posY { get; set; }

	[DataMember(Name = "dropRewardResource")]
	public ResourceData dropRewardResource { get; set; }

	public BattleInitEnemyData Clone() {
		var result = new BattleInitEnemyData();
		result.id = id;
		result.roundId = roundId;
		result.enemyId = enemyId;
		result.posX = posX;
		result.posY = posY;
		result.dropRewardResource = dropRewardResource;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
