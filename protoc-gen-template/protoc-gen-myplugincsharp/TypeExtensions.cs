using System;
using System.Collections.Generic;
using Scriban.Runtime;
using Google.Protobuf.Reflection;

public static class TypeExtensions
{
	public static string ToCsTypeName(
		this FieldDescriptorProto.Types.Type type)
	{
		return typeCsTypeDict.GetValueOrDefault(type, "");
	}

	static Dictionary<FieldDescriptorProto.Types.Type, string> typeCsTypeDict
		= new Dictionary<FieldDescriptorProto.Types.Type, string> {
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Float, "float" },
			{ FieldDescriptorProto.Types.Type.Int64, "long" },
			{ FieldDescriptorProto.Types.Type.Fixed64, "ulong" },
			{ FieldDescriptorProto.Types.Type.Int32, "int" },
			{ FieldDescriptorProto.Types.Type.Fixed32, "uint" },
			{ FieldDescriptorProto.Types.Type.Bool, "bool" },
			{ FieldDescriptorProto.Types.Type.String, "string" },
			{ FieldDescriptorProto.Types.Type.Group, "GROUP" },
			{ FieldDescriptorProto.Types.Type.Message, "MESSAGE" },
			{ FieldDescriptorProto.Types.Type.Bytes, "Google.Protobuf.ByteString" },
			{ FieldDescriptorProto.Types.Type.Uint32, "uint" },
			{ FieldDescriptorProto.Types.Type.Enum, "ENUM" },
			{ FieldDescriptorProto.Types.Type.Sfixed32, "int" },
			{ FieldDescriptorProto.Types.Type.Sfixed64, "long" },
			{ FieldDescriptorProto.Types.Type.Sint32, "int" },
			{ FieldDescriptorProto.Types.Type.Sint64, "long" },
		};

	public static string ToRbTypeName(
		this FieldDescriptorProto.Types.Type type)
	{
		return typeRbTypeDict.GetValueOrDefault(type, "");
	}

	static Dictionary<FieldDescriptorProto.Types.Type, string> typeRbTypeDict
		= new Dictionary<FieldDescriptorProto.Types.Type, string> {
			{ FieldDescriptorProto.Types.Type.Double, "Float" },
			{ FieldDescriptorProto.Types.Type.Float, "Float" },
			{ FieldDescriptorProto.Types.Type.Int64, "Integer" },
			{ FieldDescriptorProto.Types.Type.Fixed64, "Integer" },
			{ FieldDescriptorProto.Types.Type.Int32, "Integer" },
			{ FieldDescriptorProto.Types.Type.Fixed32, "Integer" },
			{ FieldDescriptorProto.Types.Type.Bool, "Boolean" },
			{ FieldDescriptorProto.Types.Type.String, "String" },
			{ FieldDescriptorProto.Types.Type.Group, "GROUP" },
			{ FieldDescriptorProto.Types.Type.Message, "MESSAGE" },
			{ FieldDescriptorProto.Types.Type.Bytes, "Google.Protobuf.ByteString" },
			{ FieldDescriptorProto.Types.Type.Uint32, "Integer" },
			{ FieldDescriptorProto.Types.Type.Enum, "ENUM" },
			{ FieldDescriptorProto.Types.Type.Sfixed32, "Integer" },
			{ FieldDescriptorProto.Types.Type.Sfixed64, "Integer" },
			{ FieldDescriptorProto.Types.Type.Sint32, "Integer" },
			{ FieldDescriptorProto.Types.Type.Sint64, "Integer" },
		};

	public static string ToRbTypeDefaultValue(
		this FieldDescriptorProto.Types.Type type)
	{
		return rbTypeDefaultValueDict
			.GetValueOrDefault(type.ToRbTypeName(), "nil");
	}

	static Dictionary<string, string> rbTypeDefaultValueDict
		= new Dictionary<string, string> {
			{ "Float",  "0.0"},
			{ "Integer", "0"  },
			{ "Boolean", "false"  },
			{ "String", "\"\""  },
			{ "Array", "[]"  },
			{ "HashSet", "{}"  },
	};
}
