using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AssetbundleData : AbstractData
{
	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "hash")]
	public string hash { get; set; }

	[DataMember(Name = "size")]
	public long size { get; set; }

	public AssetbundleData Clone() {
		var result = new AssetbundleData();
		result.name = name;
		result.hash = hash;
		result.size = size;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
