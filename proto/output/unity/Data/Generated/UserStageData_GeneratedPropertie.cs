using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserStageData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "clearCount")]
	public long clearCount { get; set; }

	[DataMember(Name = "failedCount")]
	public long failedCount { get; set; }

	[DataMember(Name = "bestClearTime")]
	public long bestClearTime { get; set; }

	public UserStageData Clone() {
		var result = new UserStageData();
		result.id = id;
		result.userId = userId;
		result.stageId = stageId;
		result.clearCount = clearCount;
		result.failedCount = failedCount;
		result.bestClearTime = bestClearTime;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
