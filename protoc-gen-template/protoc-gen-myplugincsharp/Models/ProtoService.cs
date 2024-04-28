using Google.Protobuf.Reflection;

public class ProtoService
{
	public ProtoModel Root { get; set; }

	public ProtoService(ProtoModel root, ProtoService data)
	{
		Root = root;
	}
}
