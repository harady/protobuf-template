using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;

public class ExtIndex
{
	public ProtoModel Root { get; set; }

	public ProtoMessage Message { get; set; }

	public string Name { get; set; } = string.Empty;
	public List<ProtoField> Fields { get; set; } = new();

	public bool IsUnique { get; set; } = false;

	public ExtIndex(ProtoMessage message, string indexStr, bool isUnique)
	{
		var fieldNames = indexStr.Split(',');

		Root = message.Root;
		Message = message;
		IsUnique = isUnique;

		fieldNames.ForEach(fieldName => {
			var field = message.Fields.FirstOrDefault(x => x.Name == fieldName);
			if (field == null) {
				var fields = message.Fields.Select(field => field.Name).ToList();
				throw new Exception($"インデックスで指定したフィールドがありません "
				 + $"message:{message.Name} "
				 + $"fieldName:{fieldName} "
				 + $"message.Fields:{fields.ToCSV()}");
			}
			Fields.Add(field);
		});

		Name = string.Join('_', fieldNames);
	}

	public List<ProtoField> DeepFields {
		get {
			var result = new List<ProtoField>();
			Fields.ForEach(field => {
				if (field.IsMessage) {
					var fields = field.Message.DeepFields
						.Select(field2 => field2.Clone())
						.ToList();
					fields
						.ForEach(field2 => field2.Name = $"{field.Name}.{field2.Name}");
					result.AddRange(fields);
				} else {
					result.Add(field);
				}
			});
			return result;
		}
	}

	public ProtoMessage Clone()
	{
		return (ProtoMessage)MemberwiseClone();
	}
}
