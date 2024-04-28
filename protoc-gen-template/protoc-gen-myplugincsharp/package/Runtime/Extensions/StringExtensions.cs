using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

/// <summary>
/// Stringの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static class StringExtensions
{
	/// <summary>
	/// nullまたは空か否かを返却する.
	/// </summary>
	public static bool IsNullOrEmpty(this string self)
		=> string.IsNullOrEmpty(self);

	/// <summary>
	/// nullまたは空(空白含む)か否かを返却する.
	/// </summary>
	public static bool IsNullOrWhiteSpace(this string self)
		=> (self == null || self.Trim() == "");

	/// <summary>
	/// 改行で分割した文字列の配列を取得する.
	/// </summary>
	public static string[] SplitLine(this string self)
		=> self.Split(new string[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);

	/// <summary>
	/// 改行で分割した文字列のリストを取得する.
	/// </summary>
	/// <returns>改行で分割した文字列のリスト.</returns>
	public static List<string> SplitLineList(this string self)
		=> self.SplitLine().ToList();

	/// <summary>
	/// 正規表現による置換を行う.
	/// </summary>
	public static string ReplaceRegex(
		this string self,
		string pattern,
		string replacement,
		RegexOptions options = RegexOptions.None)
			=> Regex.Replace(self, pattern, replacement, options);

	public static string Format(this string self, params object[] args)
		=> string.Format(self, args);
}
