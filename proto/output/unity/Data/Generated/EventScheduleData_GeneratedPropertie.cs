using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EventScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "questId")]
	public long questId { get; set; }

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

	public EventScheduleData Clone() {
		var result = new EventScheduleData();
		result.id = id;
		result.questId = questId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
