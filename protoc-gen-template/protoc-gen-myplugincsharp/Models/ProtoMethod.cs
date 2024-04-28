using Google.Protobuf.Reflection;

public class ProtoMethod
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; }
	public string InputType { get; set; }
	public string OutputType { get; set; }
	public MethodOptions Options { get; set; }
	public bool ClientStreaming { get; set; }
	public bool ServerStreaming { get; set; }

	public ProtoMethod(ProtoModel root, MethodDescriptorProto data)
	{
		Root = root;

		Name = data.Name;
		InputType = data.InputType;
		OutputType = data.OutputType;
		Options = data.Options;
		ClientStreaming = data.ClientStreaming;
		ServerStreaming = data.ServerStreaming;
	}
}
