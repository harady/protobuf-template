using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using MessagePack;

namespace AwsDotnetCsharp
{
	[BsonIgnoreExtraElements]
	[DataContract]
	public partial class UserPurchaseData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("userId")]
		[DataMember(Name = "userId")]
		public long userId { get; set; }

		[BsonElement("purchasePlatformType")]
		[DataMember(Name = "purchasePlatformType")]
		public PurchasePlatformType purchasePlatformType { get; set; }

		[BsonElement("shopItemId")]
		[DataMember(Name = "shopItemId")]
		public long shopItemId { get; set; }

		[BsonElement("price")]
		[DataMember(Name = "price")]
		public long price { get; set; }

		[BsonElement("googlePlayRequest")]
		[DataMember(Name = "googlePlayRequest")]
		public ShopPurchaseGooglePlayRequest googlePlayRequest { get; set; }

		[BsonElement("appStoreRequest")]
		[DataMember(Name = "appStoreRequest")]
		public ShopPurchaseAppStoreRequest appStoreRequest { get; set; }

		[BsonElement("debugRequest")]
		[DataMember(Name = "debugRequest")]
		public ShopPurchaseDebugRequest debugRequest { get; set; }

		[BsonElement("isReceiptInquired")]
		[DataMember(Name = "isReceiptInquired")]
		public bool isReceiptInquired { get; set; }

		[BsonElement("isResourceGranted")]
		[DataMember(Name = "isResourceGranted")]
		public bool isResourceGranted { get; set; }

		[BsonElement("purchaseAt")]
		[DataMember(Name = "purchaseAt")]
		public long purchaseAt { get; set; }
		[BsonIgnore]
		public DateTime PurchaseAt {
			get { return DateTimeUtil.FromEpochTime(purchaseAt); }
			set { purchaseAt = value.ToEpochTime(); }
		}

	}
}
