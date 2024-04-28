using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceData : AbstractData
{
	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public long resourceAmount { get; set; }

	[DataMember(Name = "resourceExtra")]
	public string resourceExtra { get; set; }

	public ResourceData Clone() {
		var result = new ResourceData();
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		result.resourceExtra = resourceExtra;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
