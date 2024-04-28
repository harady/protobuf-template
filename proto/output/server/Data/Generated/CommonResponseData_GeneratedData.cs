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
	public partial class CommonResponse : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("userUpdate")]
		[DataMember(Name = "userUpdate")]
		public UserUpdateData userUpdate { get; set; }

		[BsonElement("serverTime")]
		[DataMember(Name = "serverTime")]
		public long serverTime { get; set; }

		[BsonElement("appVersion")]
		[DataMember(Name = "appVersion")]
		public string appVersion { get; set; }

		[BsonElement("masterDataVersion")]
		[DataMember(Name = "masterDataVersion")]
		public long masterDataVersion { get; set; }

		[BsonElement("masterDataUrl")]
		[DataMember(Name = "masterDataUrl")]
		public string masterDataUrl { get; set; }

		[BsonElement("assetListVersion")]
		[DataMember(Name = "assetListVersion")]
		public long assetListVersion { get; set; }

		[BsonElement("assetListUrl")]
		[DataMember(Name = "assetListUrl")]
		public string assetListUrl { get; set; }

		[BsonElement("assetBaseUrl")]
		[DataMember(Name = "assetBaseUrl")]
		public string assetBaseUrl { get; set; }

	}
}
