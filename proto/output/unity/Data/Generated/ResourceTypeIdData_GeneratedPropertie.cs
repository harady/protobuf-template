using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceTypeIdData : AbstractData
{
	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	public AbilityData Clone() {
		var result = new ResourceTypeIdData();
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
