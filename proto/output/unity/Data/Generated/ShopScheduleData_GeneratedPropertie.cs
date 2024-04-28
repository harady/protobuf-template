using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ShopScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "shopId")]
	public long shopId { get; set; }

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

	public ShopScheduleData Clone() {
		var result = new ShopScheduleData();
		result.id = id;
		result.shopId = shopId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
