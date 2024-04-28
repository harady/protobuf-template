using System.Collections.Generic;
using System.Text;

/// <summary>
/// Listの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static class ListExtensions
{
	public static string ToCSV(this List<int> self, char delimiter = ',')
	{
		StringBuilder builder = new StringBuilder();
		self.ForEach(aValue => builder.Append(aValue.ToString() + delimiter));
		string result = builder.ToString().TrimEnd(delimiter);
		return result;
	}

	public static HashSet<int> ToHashSet(
		this List<int> self)
	{
		return new HashSet<int>(self);
	}
}
