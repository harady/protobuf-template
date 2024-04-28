using Google.Protobuf.Reflection;

public class ProtoModel
{
	public string Name { get; set; }
	public string Package { get; set; }
	public List<string> Dependency { get; set; }
	public List<int> PublicDependency { get; set; }
	public List<int> WeakDependency { get; set; }

	public List<ProtoMessage> MessageType { get; set; }
	public List<ProtoMessage> MessageType { get; set; }
	public List<ProtoMessage> MessageType { get; set; }
}
