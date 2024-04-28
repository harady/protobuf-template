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
	public partial class MasterData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("clientMaster")]
		[DataMember(Name = "clientMaster")]
		public ClientMasterData clientMaster { get; set; }

		[BsonElement("enemyClusters")]
		[DataMember(Name = "enemyClusters")]
		public List<EnemyClusterData> enemyClusters { get; set; } = new List<EnemyClusterData>();

		[BsonElement("enemyMappings")]
		[DataMember(Name = "enemyMappings")]
		public List<EnemyMappingData> enemyMappings { get; set; } = new List<EnemyMappingData>();

		[BsonElement("eventQuestCategorys")]
		[DataMember(Name = "eventQuestCategorys")]
		public List<EventQuestCategoryData> eventQuestCategorys { get; set; } = new List<EventQuestCategoryData>();

		[BsonElement("eventScheduleTerms")]
		[DataMember(Name = "eventScheduleTerms")]
		public List<EventScheduleTermData> eventScheduleTerms { get; set; } = new List<EventScheduleTermData>();

		[BsonElement("gachaPools")]
		[DataMember(Name = "gachaPools")]
		public List<GachaPoolData> gachaPools { get; set; } = new List<GachaPoolData>();

		[BsonElement("gachaPoolItems")]
		[DataMember(Name = "gachaPoolItems")]
		public List<GachaPoolItemData> gachaPoolItems { get; set; } = new List<GachaPoolItemData>();

	}
}
