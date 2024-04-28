using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MasterData : AbstractData
{
	[DataMember(Name = "clientMaster")]
	public ClientMasterData clientMaster { get; set; }

	[DataMember(Name = "enemyClusters")]
	public List<EnemyClusterData> enemyClusters { get; set; } = new List<EnemyClusterData>();

	[DataMember(Name = "enemyMappings")]
	public List<EnemyMappingData> enemyMappings { get; set; } = new List<EnemyMappingData>();

	[DataMember(Name = "eventQuestCategorys")]
	public List<EventQuestCategoryData> eventQuestCategorys { get; set; } = new List<EventQuestCategoryData>();

	[DataMember(Name = "eventScheduleTerms")]
	public List<EventScheduleTermData> eventScheduleTerms { get; set; } = new List<EventScheduleTermData>();

	[DataMember(Name = "gachaPools")]
	public List<GachaPoolData> gachaPools { get; set; } = new List<GachaPoolData>();

	[DataMember(Name = "gachaPoolItems")]
	public List<GachaPoolItemData> gachaPoolItems { get; set; } = new List<GachaPoolItemData>();

	public MasterData Clone() {
		var result = new MasterData();
		result.clientMaster = clientMaster;
		result.enemyClusters = enemyClusters;
		result.enemyMappings = enemyMappings;
		result.eventQuestCategorys = eventQuestCategorys;
		result.eventScheduleTerms = eventScheduleTerms;
		result.gachaPools = gachaPools;
		result.gachaPoolItems = gachaPoolItems;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
