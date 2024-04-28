using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserFriendData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "friendUserId")]
	public long friendUserId { get; set; }

	[DataMember(Name = "isFavorite")]
	public bool isFavorite { get; set; }

	[DataMember(Name = "lastUsedAt")]
	public long lastUsedAt { get; set; }

	public DateTime LastUsedAt {
		get { return ServerDateTimeUtil.FromEpoch(lastUsedAt); }
		set { lastUsedAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	[DataMember(Name = "usedCount")]
	public long usedCount { get; set; }

	public UserFriendData Clone() {
		var result = new UserFriendData();
		result.id = id;
		result.userId = userId;
		result.friendUserId = friendUserId;
		result.isFavorite = isFavorite;
		result.lastUsedAt = lastUsedAt;
		result.usedCount = usedCount;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
