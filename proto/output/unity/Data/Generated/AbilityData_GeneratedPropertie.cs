using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AbilityData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "category")]
	public AbilityCategory category { get; set; }

	[DataMember(Name = "type")]
	public AbilityType type { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	[DataMember(Name = "target")]
	public long target { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	[DataMember(Name = "paramC")]
	public long paramC { get; set; }

	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.category = category;
		result.type = type;
		result.description = description;
		result.target = target;
		result.paramA = paramA;
		result.paramB = paramB;
		result.paramC = paramC;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
