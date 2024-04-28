using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MissionGroupData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "type")]
	public MissionGroupType type { get; set; }

	public MissionGroupData Clone() {
		var result = new MissionGroupData();
		result.id = id;
		result.type = type;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
