using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ComboData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "type")]
	public ComboType type { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	[DataMember(Name = "rank")]
	public long rank { get; set; }

	[DataMember(Name = "baseAttack")]
	public long baseAttack { get; set; }

	[DataMember(Name = "maxAttack")]
	public long maxAttack { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	[DataMember(Name = "paramC")]
	public long paramC { get; set; }

	[DataMember(Name = "iconId")]
	public long iconId { get; set; }

	public ComboData Clone() {
		var result = new ComboData();
		result.id = id;
		result.name = name;
		result.type = type;
		result.description = description;
		result.rank = rank;
		result.baseAttack = baseAttack;
		result.maxAttack = maxAttack;
		result.paramA = paramA;
		result.paramB = paramB;
		result.paramC = paramC;
		result.iconId = iconId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
