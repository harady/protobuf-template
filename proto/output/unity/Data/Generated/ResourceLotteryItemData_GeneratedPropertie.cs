using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceLotteryItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "resourceLotteryId")]
	public long resourceLotteryId { get; set; }

	[DataMember(Name = "weight")]
	public long weight { get; set; }

	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	[DataMember(Name = "resourceAmountMin")]
	public long resourceAmountMin { get; set; }

	[DataMember(Name = "resourceAmountMax")]
	public long resourceAmountMax { get; set; }

	public ResourceLotteryItemData Clone() {
		var result = new ResourceLotteryItemData();
		result.id = id;
		result.resourceLotteryId = resourceLotteryId;
		result.weight = weight;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmountMin = resourceAmountMin;
		result.resourceAmountMax = resourceAmountMax;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
