using Google.Protobuf.Reflection;

public class ProtoField
{
	public ProtoModel Root { get; set; }

	public ProtoField(ProtoModel root, FieldDescriptorProto data)
	{
		Root = root;
	}
}
