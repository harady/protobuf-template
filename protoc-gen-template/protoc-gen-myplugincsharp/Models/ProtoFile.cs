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

	public List<FieldDescriptorProto> Extension { get; set; } = new();
	public Google.Protobuf.Reflection.FileOptions FileOptions { get; set; }
	public SourceCodeInfo SourceCodeInfo { get; set; } = new();
	public string Syntax { get; set; } = string.Empty;
	public UnknownFieldSet UnknownFieldSet { get; set; }

	public ProtoFile(ProtoModel root, FileDescriptorProto data)
	{
		Root = root;
		Name = data.Name;
		Package = data.Package;
		Dependency = data.Dependency.ToList();
		PublicDependency = data.PublicDependency.ToList();
		WeakDependency = data.WeakDependency.ToList();

	}
}
