using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserMissionData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "missionId")]
	public long missionId { get; set; }

	[DataMember(Name = "progress")]
	public long progress { get; set; }

	public UserMissionData Clone() {
		var result = new UserMissionData();
		result.id = id;
		result.userId = userId;
		result.missionId = missionId;
		result.progress = progress;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
