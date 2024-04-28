using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ExchangeScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "exchangeId")]
	public long exchangeId { get; set; }

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

	public ExchangeScheduleData Clone() {
		var result = new ExchangeScheduleData();
		result.id = id;
		result.exchangeId = exchangeId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
