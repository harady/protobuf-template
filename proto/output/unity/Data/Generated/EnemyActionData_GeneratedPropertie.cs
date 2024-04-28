using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EnemyActionData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "enemyId")]
	public long enemyId { get; set; }

	[DataMember(Name = "actionNo")]
	public long actionNo { get; set; }

	[DataMember(Name = "triggerType")]
	public TriggerType triggerType { get; set; }

	[DataMember(Name = "triggerParamA")]
	public long triggerParamA { get; set; }

	[DataMember(Name = "triggerParamB")]
	public long triggerParamB { get; set; }

	[DataMember(Name = "triggerParamC")]
	public long triggerParamC { get; set; }

	[DataMember(Name = "triggerParamD")]
	public long triggerParamD { get; set; }

	[DataMember(Name = "actionType")]
	public ActionType actionType { get; set; }

	[DataMember(Name = "actionParamA")]
	public long actionParamA { get; set; }

	[DataMember(Name = "actionParamB")]
	public long actionParamB { get; set; }

	[DataMember(Name = "actionParamC")]
	public long actionParamC { get; set; }

	[DataMember(Name = "actionParamD")]
	public long actionParamD { get; set; }

	public EnemyActionData Clone() {
		var result = new EnemyActionData();
		result.id = id;
		result.enemyId = enemyId;
		result.actionNo = actionNo;
		result.triggerType = triggerType;
		result.triggerParamA = triggerParamA;
		result.triggerParamB = triggerParamB;
		result.triggerParamC = triggerParamC;
		result.triggerParamD = triggerParamD;
		result.actionType = actionType;
		result.actionParamA = actionParamA;
		result.actionParamB = actionParamB;
		result.actionParamC = actionParamC;
		result.actionParamD = actionParamD;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
