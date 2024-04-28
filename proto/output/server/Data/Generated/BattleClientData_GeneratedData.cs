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
	public partial class BattleClientData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("stageId")]
		[DataMember(Name = "stageId")]
		public long stageId { get; set; }

		[BsonElement("randomSeed")]
		[DataMember(Name = "randomSeed")]
		public long randomSeed { get; set; }

		[BsonElement("battleUsers")]
		[DataMember(Name = "battleUsers")]
		public List<BattleUserData> battleUsers { get; set; } = new List<BattleUserData>();

		[BsonElement("battleInitDeck")]
		[DataMember(Name = "battleInitDeck")]
		public BattleInitDeckData battleInitDeck { get; set; }

		[BsonElement("rounds")]
		[DataMember(Name = "rounds")]
		public List<RoundData> rounds { get; set; } = new List<RoundData>();

		[BsonElement("battleInitEnemys")]
		[DataMember(Name = "battleInitEnemys")]
		public List<BattleInitEnemyData> battleInitEnemys { get; set; } = new List<BattleInitEnemyData>();

		[BsonElement("enemys")]
		[DataMember(Name = "enemys")]
		public List<EnemyData> enemys { get; set; } = new List<EnemyData>();

		[BsonElement("enemyActions")]
		[DataMember(Name = "enemyActions")]
		public List<EnemyActionData> enemyActions { get; set; } = new List<EnemyActionData>();

	}
}
