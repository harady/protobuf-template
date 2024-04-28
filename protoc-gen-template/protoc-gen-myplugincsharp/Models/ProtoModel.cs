using Google.Protobuf.Reflection;

public class ProtoModel
{
	public ProtoFile File { get; set; }
	public List<ProtoFile> Files { get; set; }

	private List<ProtoMessage> _messages = null;
	public List<ProtoMessage> Messages
		=> _messages
		?? (_messages = Files.SelectMany(file => file.MessageType.ToList()).ToList());

	public ProtoModel(FileDescriptorProto file, List<FileDescriptorProto> files)
	{
		File = new ProtoFile(this, file);
		Files = files.Select(file => new ProtoFile(this, file)).ToList();
		Files = files.Select(file => new ProtoFile(this, file)).ToList();
	}
}
