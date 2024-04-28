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
	public partial class ShopScheduleData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("shopId")]
		[DataMember(Name = "shopId")]
		public long shopId { get; set; }

		[BsonElement("openAt")]
		[DataMember(Name = "openAt")]
		public long openAt { get; set; }
		[BsonIgnore]
		public DateTime OpenAt {
			get { return DateTimeUtil.FromEpochTime(openAt); }
			set { openAt = value.ToEpochTime(); }
		}

		[BsonElement("closeAt")]
		[DataMember(Name = "closeAt")]
		public long closeAt { get; set; }
		[BsonIgnore]
		public DateTime CloseAt {
			get { return DateTimeUtil.FromEpochTime(closeAt); }
			set { closeAt = value.ToEpochTime(); }
		}

	}
}
