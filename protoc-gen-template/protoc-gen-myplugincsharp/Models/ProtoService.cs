using Google.Protobuf.Reflection;

public class ProtoService
{
	public List<FileDescriptorProto> Files { get; set; }
	public FileDescriptorProto File { get; set; }

	public List<DescriptorProto> Messages
		=> Files.SelectMany(file => file.MessageType.ToList()).ToList();
}
