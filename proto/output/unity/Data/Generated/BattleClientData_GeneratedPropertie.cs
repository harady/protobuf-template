using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleClientData : AbstractData
{
	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "randomSeed")]
	public long randomSeed { get; set; }

	[DataMember(Name = "battleUsers")]
	public List<BattleUserData> battleUsers { get; set; } = new List<BattleUserData>();

	[DataMember(Name = "battleInitDeck")]
	public BattleInitDeckData battleInitDeck { get; set; }

	[DataMember(Name = "rounds")]
	public List<RoundData> rounds { get; set; } = new List<RoundData>();

	[DataMember(Name = "battleInitEnemys")]
	public List<BattleInitEnemyData> battleInitEnemys { get; set; } = new List<BattleInitEnemyData>();

	[DataMember(Name = "enemys")]
	public List<EnemyData> enemys { get; set; } = new List<EnemyData>();

	[DataMember(Name = "enemyActions")]
	public List<EnemyActionData> enemyActions { get; set; } = new List<EnemyActionData>();

	public BattleClientData Clone() {
		var result = new BattleClientData();
		result.stageId = stageId;
		result.randomSeed = randomSeed;
		result.battleUsers = battleUsers;
		result.battleInitDeck = battleInitDeck;
		result.rounds = rounds;
		result.battleInitEnemys = battleInitEnemys;
		result.enemys = enemys;
		result.enemyActions = enemyActions;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
