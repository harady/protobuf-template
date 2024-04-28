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
	public partial class UnitEvolutionData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("type")]
		[DataMember(Name = "type")]
		public UnitEvolutionType type { get; set; }

		[BsonElement("baseUnitId")]
		[DataMember(Name = "baseUnitId")]
		public long baseUnitId { get; set; }

		[BsonElement("resultUnitId")]
		[DataMember(Name = "resultUnitId")]
		public long resultUnitId { get; set; }

		[BsonElement("costResourceSetId")]
		[DataMember(Name = "costResourceSetId")]
		public long costResourceSetId { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
