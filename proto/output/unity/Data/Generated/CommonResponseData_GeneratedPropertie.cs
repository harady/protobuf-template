using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class CommonResponse : AbstractData
{
	[DataMember(Name = "userUpdate")]
	public UserUpdateData userUpdate { get; set; }

	[DataMember(Name = "serverTime")]
	public long serverTime { get; set; }

	[DataMember(Name = "appVersion")]
	public string appVersion { get; set; }

	[DataMember(Name = "masterDataVersion")]
	public long masterDataVersion { get; set; }

	[DataMember(Name = "masterDataUrl")]
	public string masterDataUrl { get; set; }

	[DataMember(Name = "assetListVersion")]
	public long assetListVersion { get; set; }

	[DataMember(Name = "assetListUrl")]
	public string assetListUrl { get; set; }

	[DataMember(Name = "assetBaseUrl")]
	public string assetBaseUrl { get; set; }

	public CommonResponse Clone() {
		var result = new CommonResponse();
		result.userUpdate = userUpdate;
		result.serverTime = serverTime;
		result.appVersion = appVersion;
		result.masterDataVersion = masterDataVersion;
		result.masterDataUrl = masterDataUrl;
		result.assetListVersion = assetListVersion;
		result.assetListUrl = assetListUrl;
		result.assetBaseUrl = assetBaseUrl;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
