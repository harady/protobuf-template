using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserFriendRequestData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "senderUserId")]
	public long senderUserId { get; set; }

	[DataMember(Name = "targetUserId")]
	public long targetUserId { get; set; }

	public UserFriendRequestData Clone() {
		var result = new UserFriendRequestData();
		result.id = id;
		result.senderUserId = senderUserId;
		result.targetUserId = targetUserId;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
