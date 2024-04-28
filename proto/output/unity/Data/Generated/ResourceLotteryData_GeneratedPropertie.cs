using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceLotteryData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "hasEmpty")]
	public bool hasEmpty { get; set; }

	public ResourceLotteryData Clone() {
		var result = new ResourceLotteryData();
		result.id = id;
		result.name = name;
		result.hasEmpty = hasEmpty;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
