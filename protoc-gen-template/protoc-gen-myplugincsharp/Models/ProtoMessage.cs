using Google.Protobuf.Reflection;

public class ProtoMessage
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; } = string.Empty;
	public List<ProtoField> Field { get; set; } = new();
	public List<ProtoField> Extension { get; set; } = new();
	public List<ProtoMessage> NestedType { get; set; } = new();
	public List<ProtoEnum> EnumType { get; set; } = new();
	public List<DescriptorProto.Types.ExtensionRange> ExtensionRange { get; set; } = new();
	public List<OneofDescriptorProto> OneofDecl { get; set; } = new();
	public MessageOptions Options { get; set; }
	public List<DescriptorProto.Types.ReservedRange> ReservedRange { get; set; } = new();
	public List<string> ReservedName { get; set; } = new();

	public ProtoMessage(ProtoModel root, DescriptorProto data)
	{
		Root = root;

		Name = data.Name;
		Field = data.Field
			.Select(field => new ProtoField(root, field))
			.ToList();
		Extension = data.Extension
			.Select(field => new ProtoField(root, field))
			.ToList();
		NestedType = data.NestedType
			.Select(message => new ProtoMessage(root, message))
			.ToList();
		EnumType = data.EnumType
			.Select(enumType => new ProtoEnum(root, enumType))
			.ToList();
		ExtensionRange = data.ExtensionRange.ToList();
		OneofDecl = data.OneofDecl.ToList();
		Options = data.Options;
		ReservedRange = data.ReservedRange.ToList();
		ReservedName = data.ReservedName.ToList();
	}
}
