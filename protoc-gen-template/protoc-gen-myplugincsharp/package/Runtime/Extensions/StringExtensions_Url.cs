using System.Collections.Generic;

public static class StringExtensions_Url
{
	/// <summary>
	/// URL形式の文字列からQueryParameterの値を
	/// Dictionray<string, string>形式で取得する.
	/// </summary>
	public static Dictionary<string, string> GetQueryParameters(this string self)
	{
		var result = new Dictionary<string, string>();
		try {
			string query = self.Split('?')[1];
			string[] parameters = query.Split('&');
			foreach (string parameter in parameters) {
				string[] split = parameter.Split('=');
				if (split.Length == 2) {
					result[split[0]] = split[1];
				}
			}
		}
		catch {
		}
		return result;
	}

	/// <summary>
	/// URL形式の文字列からkeyで指定した値のQueryParameterを取得する.
	/// </summary>
	public static string GetQueryParameter(
		this string self, string key, string defaultVal = default)
			=> self.GetQueryParameters().GetValueOrDefault(key, defaultVal);
}
