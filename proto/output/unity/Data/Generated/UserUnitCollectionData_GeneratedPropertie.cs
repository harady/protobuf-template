using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUnitCollectionData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "unitId")]
	public long unitId { get; set; }

	[DataMember(Name = "hasEarned")]
	public bool hasEarned { get; set; }

	[DataMember(Name = "usedCount")]
	public long usedCount { get; set; }

	public UserUnitCollectionData Clone() {
		var result = new UserUnitCollectionData();
		result.id = id;
		result.userId = userId;
		result.unitId = unitId;
		result.hasEarned = hasEarned;
		result.usedCount = usedCount;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
