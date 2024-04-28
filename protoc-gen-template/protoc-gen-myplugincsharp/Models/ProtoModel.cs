using Google.Protobuf.Reflection;

public class ProtoModel
{
	public ProtoFile File { get; set; }
	public List<ProtoFile> Files { get; set; }


	private List<ProtoMessage> _messages = null;
	private List<ProtoMessage> Messages
	{
		get
		{
			if (_messages == null) {
				_messages = Files.SelectMany(file => file.Messages.ToList()).ToList();
			}
			return _messages;
		}
	}

	private Dictionary<string, ProtoMessage> _messageDict = null;

	private Dictionary<string, ProtoMessage> MessageDict
		=> _messageDict ?? (_messageDict = Messages.ToDictionary(val => val.Name));


	private List<ProtoEnum> _enums = null;
	private List<ProtoEnum> Enums
	{
		get
		{
			if (_enums == null) {
				_enums = Files.SelectMany(file => file.Enums.ToList()).ToList();
			}
			return _enums;
		}
	}

	private Dictionary<string, ProtoEnum> _enumDict = null;

	private Dictionary<string, ProtoEnum> EnumDict
		=> _enumDict ?? (_enumDict = Enums.ToDictionary(val => val.Name));


	private List<ProtoService> _services = null;
	private List<ProtoService> Services
		=> _services
		?? (_services = Files.SelectMany(file => file.Services.ToList()).ToList());

	private Dictionary<string, ProtoService> _serviceDict = null;

	private Dictionary<string, ProtoService> ServiceDict
		=> _serviceDict ?? (_serviceDict = Services.ToDictionary(val => val.Name));


	public ProtoModel(FileDescriptorProto file, List<FileDescriptorProto> files)
	{
		File = new ProtoFile(this, file);
		Files = files.Select(file => new ProtoFile(this, file)).ToList();
	}
}
