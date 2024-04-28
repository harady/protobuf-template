using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class WeakPointPositionData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "weakPointId")]
	public long weakPointId { get; set; }

	[DataMember(Name = "angle")]
	public long angle { get; set; }

	[DataMember(Name = "radiusRate")]
	public long radiusRate { get; set; }

	[DataMember(Name = "sizeRate")]
	public long sizeRate { get; set; }

	public WeakPointPositionData Clone() {
		var result = new WeakPointPositionData();
		result.id = id;
		result.weakPointId = weakPointId;
		result.angle = angle;
		result.radiusRate = radiusRate;
		result.sizeRate = sizeRate;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
