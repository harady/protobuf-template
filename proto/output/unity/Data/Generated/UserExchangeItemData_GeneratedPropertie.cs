using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserExchangeItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "exchangeItemId")]
	public long exchangeItemId { get; set; }

	[DataMember(Name = "exchangeScheduleId")]
	public long exchangeScheduleId { get; set; }

	[DataMember(Name = "exchangedCount")]
	public long exchangedCount { get; set; }

	public UserExchangeItemData Clone() {
		var result = new UserExchangeItemData();
		result.id = id;
		result.userId = userId;
		result.exchangeItemId = exchangeItemId;
		result.exchangeScheduleId = exchangeScheduleId;
		result.exchangedCount = exchangedCount;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
