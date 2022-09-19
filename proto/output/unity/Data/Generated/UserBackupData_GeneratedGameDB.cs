using System.Collections.Generic;


[DataContract]
public partial class UserBackupData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "backupType")]
	public BackupType backupType { get; set; }

	[DataMember(Name = "backupToken")]
	public string backupToken { get; set; }

	public UserBackupData Clone() {
		var result = new UserBackupData();
		result.id = id;
		result.userId = userId;
		result.backupType = backupType;
		result.backupToken = backupToken;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
