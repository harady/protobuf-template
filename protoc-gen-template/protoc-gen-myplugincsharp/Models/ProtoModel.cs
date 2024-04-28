using Google.Protobuf.Reflection;

public class ProtoModel
{
	public ProtoFile File { get; set; }
	public List<ProtoFile> Files { get; set; }


	private Dictionary<string, ProtoMessage> _messageDict = null;

	private Dictionary<string, ProtoMessage> MessageDict
	{
		get
		{
			if (_messageDict == null) {
				var messages = Files
					.SelectMany(file => file.Messages.ToList());
				_messageDict = messages.ToDictionary(val => val.Name);
			}
			return _messageDict;
		}
	}

	public ProtoMessage GetMessageByName(string name)
	{
		return MessageDict.GetValueOrDefault(name);
	}


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
	{
		get
		{
			if (_enumDict == null) {
				var enums = Files
					.SelectMany(file => file.Enums.ToList());
				_enumDict = enums.ToDictionary(val => val.Name);
			}
			return _enumDict;
		}
	}

	public ProtoEnum GetEnumByName(string name)
	{
		return EnumDict.GetValueOrDefault(name);
	}


	private Dictionary<string, ProtoService> _serviceDict = null;

	private Dictionary<string, ProtoService> ServiceDict
	{
		get
		{
			if (_serviceDict == null) {
				var services = Files
					.SelectMany(file => file.Services.ToList());
				_serviceDict = services.ToDictionary(val => val.Name);
			}
			return _serviceDict;
		}
	}

	public ProtoService GetServiceByName(string name)
	{
		return ServiceDict.GetValueOrDefault(name);
	}

	public ProtoModel(FileDescriptorProto file, List<FileDescriptorProto> files)
	{
		File = new ProtoFile(this, file);
		Files = files.Select(file => new ProtoFile(this, file)).ToList();
	}

	public ProtoModel Clone()
	{
		return (ProtoModel)MemberwiseClone();
	}
}
