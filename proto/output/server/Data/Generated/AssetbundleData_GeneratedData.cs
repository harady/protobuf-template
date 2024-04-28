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
	public partial class AssetbundleData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("hash")]
		[DataMember(Name = "hash")]
		public string hash { get; set; }

		[BsonElement("size")]
		[DataMember(Name = "size")]
		public long size { get; set; }

	}
}
