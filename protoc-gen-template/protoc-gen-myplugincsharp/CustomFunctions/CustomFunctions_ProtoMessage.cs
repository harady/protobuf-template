using System;
using Google.Protobuf.Reflection;
using Scriban.Runtime;

public static class CustomFunctions_ProtoMessage
{

	private static List<string> GetOptions(this ProtoMessage param, string optionName)
	{
		var result = new List<string>();
		param.ReservedName
			.Where(val => val.StartsWith($"{optionName}:"))
			.ForEach(val => result.Add(val.Replace($"{optionName}:", "")));
		return result;
	}

	public static List<string> GetPrimaryKeys(this ProtoMessage self)
	{
		return GetOptions(self, "primary_key");
	}

	public static List<string> GetIndexs(this ProtoMessage self)
	{
		return GetOptions(self, "index");
	}

	public static List<string> GetUniqueIndexs(this ProtoMessage self)
	{
		return GetOptions(self, "unique_index");
	}

	public static List<string> GetTags(this ProtoMessage self)
	{
		return GetOptions(self, "tag");
	}

	public static void SetupCustomFunction(ScriptObject target)
	{
		target.Import("get_primary_keys",
			new Func<ProtoMessage, List<string>>(target => target.GetPrimaryKeys()));
		target.Import("get_indexs",
			new Func<ProtoMessage, List<string>>(target => target.GetIndexs()));
		target.Import("get_unique_indexs",
			new Func<ProtoMessage, List<string>>(target => target.GetUniqueIndexs()));
		target.Import("get_tags",
			new Func<ProtoMessage, List<string>>(target => target.GetTags()));
	}
}
