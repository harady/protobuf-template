using Google.Protobuf.Reflection;

public class ProtoEnum
{
	public ProtoModel Root { get; set; }

	public ProtoEnum(ProtoModel root, EnumDescriptorProto data)
	{
		Root = root;
	}

}
