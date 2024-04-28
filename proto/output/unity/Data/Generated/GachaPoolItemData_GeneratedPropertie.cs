using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaPoolItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "gachaPoolId")]
	public long gachaPoolId { get; set; }

	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public long resourceAmount { get; set; }

	[DataMember(Name = "weight")]
	public long weight { get; set; }

	[DataMember(Name = "openAt")]
	public long openAt { get; set; }

	public DateTime OpenAt {
		get { return ServerDateTimeUtil.FromEpoch(openAt); }
		set { openAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	[DataMember(Name = "closeAt")]
	public long closeAt { get; set; }

	public DateTime CloseAt {
		get { return ServerDateTimeUtil.FromEpoch(closeAt); }
		set { closeAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	public GachaPoolItemData Clone() {
		var result = new GachaPoolItemData();
		result.id = id;
		result.gachaPoolId = gachaPoolId;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		result.weight = weight;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
