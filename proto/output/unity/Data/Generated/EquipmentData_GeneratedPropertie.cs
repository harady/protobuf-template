using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EquipmentData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "type")]
	public EquipmentType type { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	[DataMember(Name = "iconId")]
	public long iconId { get; set; }

	public EquipmentData Clone() {
		var result = new EquipmentData();
		result.id = id;
		result.name = name;
		result.type = type;
		result.description = description;
		result.paramA = paramA;
		result.paramB = paramB;
		result.iconId = iconId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
