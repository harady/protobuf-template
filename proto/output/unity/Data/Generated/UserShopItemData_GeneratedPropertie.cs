using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserShopItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "shopItemId")]
	public long shopItemId { get; set; }

	[DataMember(Name = "shopScheduleId")]
	public long shopScheduleId { get; set; }

	[DataMember(Name = "purchasedCount")]
	public long purchasedCount { get; set; }

	public UserShopItemData Clone() {
		var result = new UserShopItemData();
		result.id = id;
		result.userId = userId;
		result.shopItemId = shopItemId;
		result.shopScheduleId = shopScheduleId;
		result.purchasedCount = purchasedCount;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
