using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ShopItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "shopId")]
	public long shopId { get; set; }

	[DataMember(Name = "purchasePlatformType")]
	public PurchasePlatformType purchasePlatformType { get; set; }

	[DataMember(Name = "platformProductId")]
	public string platformProductId { get; set; }

	[DataMember(Name = "price")]
	public long price { get; set; }

	[DataMember(Name = "resourceSetId")]
	public long resourceSetId { get; set; }

	[DataMember(Name = "limitCount")]
	public long limitCount { get; set; }

	public ShopItemData Clone() {
		var result = new ShopItemData();
		result.id = id;
		result.name = name;
		result.shopId = shopId;
		result.purchasePlatformType = purchasePlatformType;
		result.platformProductId = platformProductId;
		result.price = price;
		result.resourceSetId = resourceSetId;
		result.limitCount = limitCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
