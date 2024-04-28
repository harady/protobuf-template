using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class OtherUserData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "code")]
	public long code { get; set; }

	[DataMember(Name = "rank")]
	public long rank { get; set; }

	[DataMember(Name = "userUnit")]
	public UserUnitData userUnit { get; set; }

	[DataMember(Name = "isFriend")]
	public bool isFriend { get; set; }

	public OtherUserData Clone() {
		var result = new OtherUserData();
		result.id = id;
		result.name = name;
		result.code = code;
		result.rank = rank;
		result.userUnit = userUnit;
		result.isFriend = isFriend;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
