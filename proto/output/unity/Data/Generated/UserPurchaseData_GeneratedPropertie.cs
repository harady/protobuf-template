using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserPurchaseData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "purchasePlatformType")]
	public PurchasePlatformType purchasePlatformType { get; set; }

	[DataMember(Name = "shopItemId")]
	public long shopItemId { get; set; }

	[DataMember(Name = "price")]
	public long price { get; set; }

	[DataMember(Name = "googlePlayRequest")]
	public ShopPurchaseGooglePlayRequest googlePlayRequest { get; set; }

	[DataMember(Name = "appStoreRequest")]
	public ShopPurchaseAppStoreRequest appStoreRequest { get; set; }

	[DataMember(Name = "debugRequest")]
	public ShopPurchaseDebugRequest debugRequest { get; set; }

	[DataMember(Name = "isReceiptInquired")]
	public bool isReceiptInquired { get; set; }

	[DataMember(Name = "isResourceGranted")]
	public bool isResourceGranted { get; set; }

	[DataMember(Name = "purchaseAt")]
	public long purchaseAt { get; set; }

	public DateTime PurchaseAt {
		get { return ServerDateTimeUtil.FromEpoch(purchaseAt); }
		set { purchaseAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	public UserPurchaseData Clone() {
		var result = new UserPurchaseData();
		result.id = id;
		result.userId = userId;
		result.purchasePlatformType = purchasePlatformType;
		result.shopItemId = shopItemId;
		result.price = price;
		result.googlePlayRequest = googlePlayRequest;
		result.appStoreRequest = appStoreRequest;
		result.debugRequest = debugRequest;
		result.isReceiptInquired = isReceiptInquired;
		result.isResourceGranted = isResourceGranted;
		result.purchaseAt = purchaseAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
