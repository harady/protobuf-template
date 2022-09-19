using System.Collections.Generic;


[DataContract]
public partial class QuestGroupData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "type")]
	public QuestGroupType type { get; set; }

	public QuestGroupData Clone() {
		var result = new QuestGroupData();
		result.id = id;
		result.name = name;
		result.type = type;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
