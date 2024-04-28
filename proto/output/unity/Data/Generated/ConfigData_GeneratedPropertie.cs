using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ConfigData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "key")]
	public string key { get; set; }

	[DataMember(Name = "value")]
	public long value { get; set; }

	[DataMember(Name = "text")]
	public string text { get; set; }

	public ConfigData Clone() {
		var result = new ConfigData();
		result.id = id;
		result.key = key;
		result.value = value;
		result.text = text;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
