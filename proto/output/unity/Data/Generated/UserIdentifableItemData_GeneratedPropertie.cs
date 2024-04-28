using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserIdentifableItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "identifableItemId")]
	public long identifableItemId { get; set; }

	[DataMember(Name = "paramA")]
	public long paramA { get; set; }

	[DataMember(Name = "paramB")]
	public long paramB { get; set; }

	public UserIdentifableItemData Clone() {
		var result = new UserIdentifableItemData();
		result.id = id;
		result.userId = userId;
		result.identifableItemId = identifableItemId;
		result.paramA = paramA;
		result.paramB = paramB;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
