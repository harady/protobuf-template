using System;
using System.Collections.Generic;

/// <summary>
/// バージョンコードに関するStringの拡張メソッド群.
/// </summary>
public static class StringExtensions_VersionCode
{
	public static int ToVersionCode(this string self)
	{
		int result = GetVersionCode(self);
		return result;
	}

	/// <summary>
	/// valで指定した文字列をバージョンコードに変換.
	/// </summary>
	/// <returns>バージョンコード.</returns>
	/// <param name="val">バージョンコードに変換する文字列.</param>
	private static int GetVersionCode(string val)
	{
		string[] numbers = val.Split('.');
		// 番号のリストに変換する.
		var numList = new List<int>();
		numbers.ForEach(aNumber => numList.Add(Convert.ToInt32(aNumber)));
		// 足りない部分に0を追加する.
		while (numList.Count < 3) { numList.Add(0); }
		// 順序をFixバージョン → Majorバージョンになるように反転.
		numList.Reverse();
		// intに変換.
		int result = 0;
		for (int i = 0; i < numList.Count; i++) {
			result += (int)(numList[i] * Math.Pow(1000.0f, (double)i));
		}
		return result;
	}
}
