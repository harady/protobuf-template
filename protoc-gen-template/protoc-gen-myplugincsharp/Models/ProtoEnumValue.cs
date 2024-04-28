using Google.Protobuf.Reflection;

public class ProtoEnumValue
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; }
	public int Number { get; set; }
	public EnumValueOptions Options { get; set; }

	public ProtoEnumValue(ProtoModel root, EnumValueDescriptorProto data)
	{
		Root = root;

		Name = data.Name;
		Number = data.Number;
		Options = data.Options;
	}

}
