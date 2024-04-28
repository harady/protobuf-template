/// <summary>
/// 表記手法変換に関するStringの拡張メソッド群.
/// </summary>
public static class StringExtensions_CaseConvent
{
	public static string[] ToWords(this string self)
	{
		var regex = new System.Text.RegularExpressions.Regex("[a-z][A-Z]");
		var tmp = regex.Replace(self, s => $"{s.Groups[0].Value[0]}_{s.Groups[0].Value[1]}");
		return tmp.Split('_');
	}

	/// <summary>
	/// この文字列のキャメルケース表現を取得する.
	/// </summary>
	public static string ToCamelCase(this string self)
		=> GetCamelCase(self.ToWords());

	/// <summary>
	/// この文字列のパスカルケース表現を取得する.
	/// </summary>
	public static string ToPascalCase(this string self)
		=> GetPascalCase(self.ToWords());

	/// <summary>
	/// この文字列のスネークケース表現を取得する.
	/// </summary>
	public static string ToSnakeCase(this string self)
		=> GetSnakeCase(self.ToWords());

	/// <summary>
	/// この文字列のアッパースネークケース表現を取得する.
	/// </summary>
	public static string ToUpperSnakeCase(this string self)
		=> GetUpperSnakeCase(self.ToWords());

	/// <summary>
	/// wordsをキャメルケース表現に変換する.
	/// </summary>
	private static string GetCamelCase(string[] wordList)
	{
		string result = "";
		foreach (string aWord in wordList) {
			string aWordLower = aWord.ToLowerInvariant();
			if (result.IsNullOrEmpty()) {
				result
					+= aWordLower[0].ToString().ToLowerInvariant()
						+ aWordLower.Substring(1);
			} else {
				result
					+= aWordLower[0].ToString().ToUpperInvariant()
						+ aWordLower.Substring(1);
			}
		}
		return result;
	}

	/// <summary>
	/// wordsをパスカルケース表現に変換する.
	/// </summary>
	private static string GetPascalCase(string[] words)
	{
		string result = "";
		foreach (string aWord in words) {
			string aWordLower = aWord.ToLowerInvariant();
			result
				+= aWordLower[0].ToString().ToUpperInvariant()
					+ aWordLower.Substring(1);
		}
		return result;
	}

	/// <summary>
	/// wordsをスネークケース表現に変換する.
	/// </summary>
	private static string GetSnakeCase(string[] words)
	{
		string result = "";
		foreach (string aWord in words) {
			result += aWord.ToLowerInvariant() + "_";
		}
		result = result.TrimEnd('_');
		return result;
	}

	/// <summary>
	/// wordsをアッパースネークケース表現に変換する.
	/// </summary>
	private static string GetUpperSnakeCase(string[] words)
	{
		string result = "";
		foreach (string aWord in words) {
			result += aWord.ToUpperInvariant() + "_";
		}
		result = result.TrimEnd('_');
		return result;
	}
}
