using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "attribute")]
	public long attribute { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	[DataMember(Name = "category")]
	public ItemCategory category { get; set; }

	[DataMember(Name = "type")]
	public ItemType type { get; set; }

	[DataMember(Name = "ownedLimit")]
	public long ownedLimit { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	public ItemData Clone() {
		var result = new ItemData();
		result.id = id;
		result.name = name;
		result.attribute = attribute;
		result.description = description;
		result.category = category;
		result.type = type;
		result.ownedLimit = ownedLimit;
		result.paramA = paramA;
		result.paramB = paramB;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
