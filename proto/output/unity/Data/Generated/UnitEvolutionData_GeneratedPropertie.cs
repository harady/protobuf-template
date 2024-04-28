using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitEvolutionData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "type")]
	public UnitEvolutionType type { get; set; }

	[DataMember(Name = "baseUnitId")]
	public long baseUnitId { get; set; }

	[DataMember(Name = "resultUnitId")]
	public long resultUnitId { get; set; }

	[DataMember(Name = "costResourceSetId")]
	public long costResourceSetId { get; set; }

	public UnitEvolutionData Clone() {
		var result = new UnitEvolutionData();
		result.id = id;
		result.name = name;
		result.type = type;
		result.baseUnitId = baseUnitId;
		result.resultUnitId = resultUnitId;
		result.costResourceSetId = costResourceSetId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
