using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaButtonData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "gachaId")]
	public long gachaId { get; set; }

	[DataMember(Name = "viewOrder")]
	public long viewOrder { get; set; }

	[DataMember(Name = "drawCount")]
	public long drawCount { get; set; }

	[DataMember(Name = "extraCount")]
	public long extraCount { get; set; }

	[DataMember(Name = "guaranteeCount")]
	public long guaranteeCount { get; set; }

	[DataMember(Name = "purchaseCount")]
	public long purchaseCount { get; set; }

	[DataMember(Name = "costResourceType")]
	public ResourceType costResourceType { get; set; }

	[DataMember(Name = "costResourceId")]
	public long costResourceId { get; set; }

	[DataMember(Name = "costResourceAmount")]
	public long costResourceAmount { get; set; }

	public GachaButtonData Clone() {
		var result = new GachaButtonData();
		result.id = id;
		result.name = name;
		result.gachaId = gachaId;
		result.viewOrder = viewOrder;
		result.drawCount = drawCount;
		result.extraCount = extraCount;
		result.guaranteeCount = guaranteeCount;
		result.purchaseCount = purchaseCount;
		result.costResourceType = costResourceType;
		result.costResourceId = costResourceId;
		result.costResourceAmount = costResourceAmount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
