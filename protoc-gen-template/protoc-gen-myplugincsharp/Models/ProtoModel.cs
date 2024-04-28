using Google.Protobuf.Reflection;

public class ProtoModel
{
	public FileDescriptorProto File { get; set; }
	public List<FileDescriptorProto> Files { get; set; }

	private List<DescriptorProto> _messages = null;
	public List<DescriptorProto> Messages
		=> _messages
		?? (_messages = Files.SelectMany(file => file.MessageType.ToList()).ToList());

	public ProtoModel(FileDescriptorProto file, List<FileDescriptorProto> files)
	{
		File = file;
		Files = files;
	}
}
