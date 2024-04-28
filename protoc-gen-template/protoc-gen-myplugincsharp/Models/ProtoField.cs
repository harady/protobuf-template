using Google.Protobuf.Reflection;

public class ProtoField
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; }
	public int Number { get; set; }
	public FieldDescriptorProto.Types.Label Label { get; set; }
	public FieldDescriptorProto.Types.Type Type { get; set; }
	public string TypeName { get; set; }
	public string Extendee { get; set; }
	public string DefaultValue { get; set; }
	public int OneofIndex { get; set; }
	public string JsonName { get; set; }
	public FieldOptions Options { get; set; }
	public bool Proto3Optional { get; set; }

	public ProtoField(ProtoModel root, FieldDescriptorProto data)
	{
		Root = root;

		Name = data.Name;
		Number = data.Number;
		Label = data.Label;
		Type = data.Type;
		TypeName = data.TypeName;
		Extendee = data.Extendee;
		DefaultValue = data.DefaultValue;
		OneofIndex = data.OneofIndex;
		JsonName = data.JsonName;
		Options = data.Options;
		Proto3Optional = data.Proto3Optional;
	}
}
