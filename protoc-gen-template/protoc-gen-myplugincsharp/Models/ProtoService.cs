using Google.Protobuf.Reflection;

public class ProtoService
{
	public ProtoModel Root { get; set; }

	public ProtoService(ProtoModel root, ServiceDescriptorProto data)
	{
		Root = root;
	}
}
