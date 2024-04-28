using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserPaidCrystalData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "purchasePlatformType")]
	public PurchasePlatformType purchasePlatformType { get; set; }

	[DataMember(Name = "amount")]
	public long amount { get; set; }

	public UserPaidCrystalData Clone() {
		var result = new UserPaidCrystalData();
		result.id = id;
		result.userId = userId;
		result.purchasePlatformType = purchasePlatformType;
		result.amount = amount;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
