using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AssetbundleListData : AbstractData
{
	[DataMember(Name = "version")]
	public long version { get; set; }

	[DataMember(Name = "assetbundles")]
	public List<AssetbundleData> assetbundles { get; set; } = new List<AssetbundleData>();

	public AssetbundleListData Clone() {
		var result = new AssetbundleListData();
		result.version = version;
		result.assetbundles = assetbundles;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
