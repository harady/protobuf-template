using Google.Protobuf;
using Google.Protobuf.Reflection;

public class ProtoFile
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; } = string.Empty;
	public string Package { get; set; } = string.Empty;
	public List<string> Dependency { get; set; } = new();
	public List<int> PublicDependency { get; set; } = new();
	public List<int> WeakDependency { get; set; } = new();

	public List<ProtoMessage> MessageType { get; set; } = new();
	public List<ProtoMessage> Messages => MessageType;

	public List<ProtoEnum> EnumType { get; set; } = new();
	public List<ProtoEnum> Enums => EnumType;

	public List<ProtoService> Service { get; set; } = new();
	public List<ProtoService> Services => Service;

	public List<ProtoField> Extension { get; set; } = new();
	public Google.Protobuf.Reflection.FileOptions Options { get; set; }
	public SourceCodeInfo SourceCodeInfo { get; set; } = new();
	public string Syntax { get; set; } = string.Empty;

	public ProtoFile(ProtoModel root, FileDescriptorProto data)
	{
		Root = root;
		Name = data.Name;
		Package = data.Package;
		Dependency = data.Dependency.ToList();
		PublicDependency = data.PublicDependency.ToList();
		WeakDependency = data.WeakDependency.ToList();
		MessageType = data.MessageType
			.Select(message => new ProtoMessage(Root, message))
			.ToList();
		EnumType = data.EnumType
			.Select(enumType => new ProtoEnum(Root, enumType))
			.ToList();
		Service = data.Service
			.Select(service => new ProtoService(Root, service))
			.ToList();
		Extension = data.Extension
			.Select(field => new ProtoField(Root, field))
			.ToList();
		Options = data.Options;
		SourceCodeInfo = data.SourceCodeInfo;
		Syntax = data.Syntax;
	}
}
