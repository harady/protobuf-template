using Google.Protobuf.Reflection;

public class ProtoFile
{
	public string Name { get; set; } = string.Empty;
	public string Package { get; set; } = string.Empty;
	public List<string> Dependency { get; set; } = new();
	public List<int> PublicDependency { get; set; } = new();
	public List<int> WeakDependency { get; set; } = new();
	public List<ProtoMessage> MessageType { get; set; } = new();
	public List<ProtoEnum> EnumType { get; set; } = new();
	public List<ProtoService> Service { get; set; } = new();

	public ProtoFile(FileDescriptorProto data)
	{
		Name = data.Name;
		Package = data.Package;
		Dependency = data.Dependency.ToList();
		PublicDependency = data.PublicDependency.ToList();
		WeakDependency = data.WeakDependency.ToList();

	}
}
