using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleServerData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	public BattleServerData Clone() {
		var result = new BattleServerData();
		result.id = id;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
