using System.Collections.Generic;


[DataContract]
public partial class ExchangeData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "type")]
	public ExchangeType type { get; set; }

	public ExchangeData Clone() {
		var result = new ExchangeData();
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
