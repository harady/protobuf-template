using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ExchangeItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "exchangeId")]
	public long exchangeId { get; set; }

	[DataMember(Name = "costResourceType")]
	public ResourceType costResourceType { get; set; }

	[DataMember(Name = "costResourceId")]
	public long costResourceId { get; set; }

	[DataMember(Name = "costResourceAmount")]
	public long costResourceAmount { get; set; }

	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public long resourceAmount { get; set; }

	[DataMember(Name = "resourceSetId")]
	public long resourceSetId { get; set; }

	[DataMember(Name = "limitCount")]
	public long limitCount { get; set; }

	public ExchangeItemData Clone() {
		var result = new ExchangeItemData();
		result.id = id;
		result.name = name;
		result.exchangeId = exchangeId;
		result.costResourceType = costResourceType;
		result.costResourceId = costResourceId;
		result.costResourceAmount = costResourceAmount;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		result.resourceSetId = resourceSetId;
		result.limitCount = limitCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
