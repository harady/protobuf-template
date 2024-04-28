using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class CommonRequest : AbstractData
{
	[DataMember(Name = "sessionId")]
	public string sessionId { get; set; }

	public CommonRequest Clone() {
		var result = new CommonRequest();
		result.sessionId = sessionId;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
