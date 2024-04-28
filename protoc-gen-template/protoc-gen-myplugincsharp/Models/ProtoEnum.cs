using Google.Protobuf.Reflection;

public class ProtoEnum
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; }
	public List<ProtoEnumValue> Value { get; set; }
	public List<ProtoEnumValue> Values => Value;
	public EnumOptions Options { get; set; }
	public List<EnumDescriptorProto.Types.EnumReservedRange> ReservedRange { get; set; }
	public List<string> ReservedName { get; set; }

	public ProtoEnum(ProtoModel root, EnumDescriptorProto data)
	{
		Root = root;

		Name = data.Name;
		Value = data.Value
			.Select(val => new ProtoEnumValue(root, val))
			.ToList();
		Options = data.Options;
		ReservedRange = data.ReservedRange.ToList();
		ReservedName = data.ReservedName.ToList();
	}

	public ProtoEnum Clone()
	{
		return (ProtoEnum)MemberwiseClone();
	}
}
