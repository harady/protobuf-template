using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaResultItemData : AbstractData
{
	[DataMember(Name = "resource")]
	public ResourceData resource { get; set; }

	[DataMember(Name = "isExtra")]
	public bool isExtra { get; set; }

	[DataMember(Name = "isPickup")]
	public bool isPickup { get; set; }

	[DataMember(Name = "isGuarantee")]
	public bool isGuarantee { get; set; }

	public GachaResultItemData Clone() {
		var result = new GachaResultItemData();
		result.resource = resource;
		result.isExtra = isExtra;
		result.isPickup = isPickup;
		result.isGuarantee = isGuarantee;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
