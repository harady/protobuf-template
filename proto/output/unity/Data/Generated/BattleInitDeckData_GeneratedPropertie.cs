using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleInitDeckData : AbstractData
{
	[DataMember(Name = "userUnits")]
	public List<UserUnitData> userUnits { get; set; } = new List<UserUnitData>();

	public BattleInitDeckData Clone() {
		var result = new BattleInitDeckData();
		result.userUnits = userUnits;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
