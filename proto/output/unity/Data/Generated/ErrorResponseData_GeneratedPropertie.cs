using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ErrorResponse : AbstractData
{
	[DataMember(Name = "code")]
	public int code { get; set; }

	[DataMember(Name = "title")]
	public string title { get; set; }

	[DataMember(Name = "message")]
	public string message { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	public ErrorResponse Clone() {
		var result = new ErrorResponse();
		result.code = code;
		result.title = title;
		result.message = message;
		result.description = description;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
