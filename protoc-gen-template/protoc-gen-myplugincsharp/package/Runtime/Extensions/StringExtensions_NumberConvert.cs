using System;

/// <summary>
/// Stringの数値変換に関する拡張メソッドを定義したクラス.
/// </summary>
public static class StringExtensions_NumberConvert
{
	public static int ToInt32(this string self, int defaultVal = 0)
	{
		int result;
		if (!int.TryParse(self, out result)) {
			result = defaultVal;
		}
		return result;
	}

	public static long ToInt64(this string self, long defaultVal = 0)
	{
		long result;
		if (!long.TryParse(self, out result)) {
			result = defaultVal;
		}
		return result;
	}

	public static float ToSingle(this string self, float defaultVal = 0.0f)
	{
		float result;
		if (!float.TryParse(self, out result)) {
			result = defaultVal;
		}
		return result;
	}
}
