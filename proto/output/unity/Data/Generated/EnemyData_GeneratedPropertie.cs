using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EnemyData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "unitId")]
	public long unitId { get; set; }

	[DataMember(Name = "hp")]
	public long hp { get; set; }

	[DataMember(Name = "size")]
	public long size { get; set; }

	[DataMember(Name = "weakPointId")]
	public long weakPointId { get; set; }

	[DataMember(Name = "isBoss")]
	public bool isBoss { get; set; }

	[DataMember(Name = "isEscape")]
	public bool isEscape { get; set; }

	[DataMember(Name = "damageRate")]
	public long damageRate { get; set; }

	[DataMember(Name = "directDamageRate")]
	public long directDamageRate { get; set; }

	[DataMember(Name = "indirectDamageRate")]
	public long indirectDamageRate { get; set; }

	[DataMember(Name = "baseEnemyId")]
	public long baseEnemyId { get; set; }

	[DataMember(Name = "dropRate")]
	public long dropRate { get; set; }

	[DataMember(Name = "rewardResourceLotteryId")]
	public long rewardResourceLotteryId { get; set; }

	public EnemyData Clone() {
		var result = new EnemyData();
		result.id = id;
		result.name = name;
		result.unitId = unitId;
		result.hp = hp;
		result.size = size;
		result.weakPointId = weakPointId;
		result.isBoss = isBoss;
		result.isEscape = isEscape;
		result.damageRate = damageRate;
		result.directDamageRate = directDamageRate;
		result.indirectDamageRate = indirectDamageRate;
		result.baseEnemyId = baseEnemyId;
		result.dropRate = dropRate;
		result.rewardResourceLotteryId = rewardResourceLotteryId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
