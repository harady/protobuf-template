using Google.Protobuf.Reflection;

public class ProtoService
{
	public ProtoModel Root { get; set; }

	public string Name { get; set; }
	public List<ProtoMethod> Method { get; set; }
	public List<ProtoMethod> Methods => Method;
	public ServiceOptions Options { get; set; }

	public ProtoService(ProtoModel root, ServiceDescriptorProto data)
	{
		Root = root;
		Name = data.Name;
		Method = data.Method
			.Select(method => new ProtoMethod(Root, method))
			.ToList();
		Options = data.Options;
	}

	public ProtoService Clone()
	{
		return (ProtoService)MemberwiseClone();
	}
}
