using Google.Protobuf.Reflection;

public class ProtoMessage
{
	public ProtoModel Root { get; set; }

	public ProtoMessage(ProtoModel root, DescriptorProto data)
	{
		Root = root;
	}
}
