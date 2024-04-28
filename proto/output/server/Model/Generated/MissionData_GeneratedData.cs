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
	public partial class MissionData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("name")]
		[DataMember(Name = "name")]
		public string name { get; set; }

		[BsonElement("missionGroupId")]
		[DataMember(Name = "missionGroupId")]
		public long missionGroupId { get; set; }

		[BsonElement("type")]
		[DataMember(Name = "type")]
		public MissionType type { get; set; }

		[BsonElement("toAchieveProgress")]
		[DataMember(Name = "toAchieveProgress")]
		public long toAchieveProgress { get; set; }

		[BsonElement("paramA")]
		[DataMember(Name = "paramA")]
		public long paramA { get; set; }

		[BsonElement("paramB")]
		[DataMember(Name = "paramB")]
		public long paramB { get; set; }

		[BsonElement("rewardResourceType")]
		[DataMember(Name = "rewardResourceType")]
		public ResourceType rewardResourceType { get; set; }

		[BsonElement("rewardResourceId")]
		[DataMember(Name = "rewardResourceId")]
		public long rewardResourceId { get; set; }

		[BsonElement("rewardResourceAmount")]
		[DataMember(Name = "rewardResourceAmount")]
		public long rewardResourceAmount { get; set; }


		public string idNameText => GetIdNameText(id, name);
	}
}
