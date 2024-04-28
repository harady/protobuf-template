using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaPoolData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "gachaId")]
	public long gachaId { get; set; }

	[DataMember(Name = "baseGachaPoolId")]
	public long baseGachaPoolId { get; set; }

	[DataMember(Name = "isExtra")]
	public bool isExtra { get; set; }

	[DataMember(Name = "isPickup")]
	public bool isPickup { get; set; }

	[DataMember(Name = "isGuarantee")]
	public bool isGuarantee { get; set; }

	[DataMember(Name = "rarity")]
	public long rarity { get; set; }

	[DataMember(Name = "attribute")]
	public UnitAttribute attribute { get; set; }

	[DataMember(Name = "weight")]
	public long weight { get; set; }

	public GachaPoolData Clone() {
		var result = new GachaPoolData();
		result.id = id;
		result.name = name;
		result.gachaId = gachaId;
		result.baseGachaPoolId = baseGachaPoolId;
		result.isExtra = isExtra;
		result.isPickup = isPickup;
		result.isGuarantee = isGuarantee;
		result.rarity = rarity;
		result.attribute = attribute;
		result.weight = weight;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
