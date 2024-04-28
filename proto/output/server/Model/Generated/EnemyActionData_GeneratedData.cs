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
	public partial class EnemyActionData : AbstractData
	{
		[BsonId]
		public ObjectId _id { get; set; }
		[BsonElement("id")]
		[DataMember(Name = "id")]
		public long id { get; set; }

		[BsonElement("enemyId")]
		[DataMember(Name = "enemyId")]
		public long enemyId { get; set; }

		[BsonElement("actionNo")]
		[DataMember(Name = "actionNo")]
		public long actionNo { get; set; }

		[BsonElement("triggerType")]
		[DataMember(Name = "triggerType")]
		public TriggerType triggerType { get; set; }

		[BsonElement("triggerParamA")]
		[DataMember(Name = "triggerParamA")]
		public long triggerParamA { get; set; }

		[BsonElement("triggerParamB")]
		[DataMember(Name = "triggerParamB")]
		public long triggerParamB { get; set; }

		[BsonElement("triggerParamC")]
		[DataMember(Name = "triggerParamC")]
		public long triggerParamC { get; set; }

		[BsonElement("triggerParamD")]
		[DataMember(Name = "triggerParamD")]
		public long triggerParamD { get; set; }

		[BsonElement("actionType")]
		[DataMember(Name = "actionType")]
		public ActionType actionType { get; set; }

		[BsonElement("actionParamA")]
		[DataMember(Name = "actionParamA")]
		public long actionParamA { get; set; }

		[BsonElement("actionParamB")]
		[DataMember(Name = "actionParamB")]
		public long actionParamB { get; set; }

		[BsonElement("actionParamC")]
		[DataMember(Name = "actionParamC")]
		public long actionParamC { get; set; }

		[BsonElement("actionParamD")]
		[DataMember(Name = "actionParamD")]
		public long actionParamD { get; set; }

	}
}
