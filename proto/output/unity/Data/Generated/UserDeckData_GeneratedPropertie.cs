using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserDeckData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "deckNo")]
	public long deckNo { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "userUnit1Id")]
	public long userUnit1Id { get; set; }

	[DataMember(Name = "userUnit2Id")]
	public long userUnit2Id { get; set; }

	[DataMember(Name = "userUnit3Id")]
	public long userUnit3Id { get; set; }

	public UserDeckData Clone() {
		var result = new UserDeckData();
		result.id = id;
		result.userId = userId;
		result.deckNo = deckNo;
		result.name = name;
		result.userUnit1Id = userUnit1Id;
		result.userUnit2Id = userUnit2Id;
		result.userUnit3Id = userUnit3Id;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
