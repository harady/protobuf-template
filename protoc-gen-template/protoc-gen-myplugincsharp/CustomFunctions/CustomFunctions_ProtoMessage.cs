using System;
using Google.Protobuf.Reflection;
using Scriban.Runtime;

public class CustomFunctions_ProtoMessage
{

	private static List<string> GetOptions(ProtoMessage param, string optionName)
	{
		var result = new List<string>();
		param.ReservedName
			.Where(val => val.StartsWith($"{optionName}:"))
			.ForEach(val => result.Add(val.Replace($"{optionName}:", "")));
		return result;
	}

	public static List<string> GetPrimaryKeys(ProtoMessage param)
	{
		return GetOptions(param, "primary_key");
	}

	public static List<string> GetIndexs(ProtoMessage param)
	{
		return GetOptions(param, "index");
	}

	public static List<string> GetUniqueIndexs(ProtoMessage param)
	{
		return GetOptions(param, "unique_index");
	}

	public static List<string> GetTags(ProtoMessage param)
	{
		return GetOptions(param, "tag");
	}

	public static void SetupCustomFunction(ScriptObject target)
	{
		target.Import("get_primary_keys",
			new Func<ProtoMessage, List<string>>(target => GetPrimaryKeys(target)));
		target.Import("get_indexs",
			new Func<ProtoMessage, List<string>>(target => GetIndexs(target)));
		target.Import("get_unique_indexs",
			new Func<ProtoMessage, List<string>>(target => GetUniqueIndexs(target)));
		target.Import("get_tags",
			new Func<ProtoMessage, List<string>>(target => GetTags(target)));
	}
}
