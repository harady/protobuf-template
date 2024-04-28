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
	public partial class AssetbundleListData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("version")]
		[DataMember(Name = "version")]
		public long version { get; set; }

		[BsonElement("assetbundles")]
		[DataMember(Name = "assetbundles")]
		public List<AssetbundleData> assetbundles { get; set; } = new List<AssetbundleData>();

	}
}
