using System;
using Google.Protobuf.Reflection;
using Scriban.Runtime;

public class CustomFunctions_ProtoField
{
	/// <summary>
	/// このフィールドのC#における型を取得する.
	/// </summary>
	public static string ToCsType(ProtoField param)
	{
		return param.ShortTypeName;
	}

	/// <summary>
	/// このフィールドにRepeatedラベルが付いているか否かを取得する.
	/// </summary>
	public static bool IsRepeated(ProtoField param)
	{
		return param.Label == FieldDescriptorProto.Types.Label.Repeated;
	}

	/// <summary>
	/// このフィールドのRubyにおける型を取得する.
	/// </summary>
	public static string ToRbType(ProtoField param)
	{
		return param.HasTypeName
			? CustomFunctions_String.ToShortName(param.TypeName)
			: param.Type.ToRbTypeName();
	}

	/// <summary>
	/// このフィールドのRubyにおける型のデフォルト値を取得する.
	/// </summary>
	public static string ToRbTypeDefault(ProtoField param)
	{
		return param.HasTypeName
			? $"{CustomFunctions_String.ToShortName(param.TypeName)}.new"
			: param.Type.ToRbTypeDefaultValue();
	}

	public static void SetupCustomFunction(ScriptObject target)
	{
		target.Import("to_cs_type",
			new Func<ProtoField, string>(type => ToCsType(type)));

		target.Import("is_repeated",
			new Func<ProtoField, bool>(type => IsRepeated(type)));

		target.Import("to_rb_type",
			new Func<ProtoField, string>(type => ToRbType(type)));
		target.Import("to_rb_type_default",
			new Func<ProtoField, string>(type => ToRbTypeDefault(type)));

	}
}
