using System;

/// <summary>
/// intの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static class IntExtensions
{
	/// <summary>
	/// この数値を modByで割った際の剰余を返却する.
	/// </summary>
	public static int Mod(this int self, int modBy)
		=> MathEx.Mod(self, modBy);

	/// <summary>
	/// この数値を modByで割った際の剰余を返却する.
	/// </summary>
	public static int AddAndMod(this int self, int addVal, int modBy)
		=> MathEx.AddAndMod(self, addVal, modBy);

	/// <summary>
	/// この数値の桁数を取得する.
	/// 999.GetDigits() => 3
	/// (-999).GetDigits() => 3
	/// </summary>
	public static int GetDigits(this int self)
		=> (int)(Math.Log10(Math.Abs(self)) + 1);

	/// <summary>
	/// この数値のdigitで指定した桁の数を取得する.
	/// 1234.GetNumOfDigit(2) => 3
	/// (-1234).GetNumOfDigit(1) => 4
	/// 
	/// digitに0以下の値を指定した場合は0を返します。
	/// 1234.GetNumOfDigit(0) => 0
	/// 1234.GetNumOfDigit(-1) => 0
	/// </summary>
	/// <returns>数を取得する桁.</returns>
	public static int GetNumOfDigit(this int self, int digit)
	{
		if (digit <= 0) {
			return 0;
		} else {
			return Math.Abs(self) % (int)Math.Pow(10, digit) / (int)Math.Pow(10, digit - 1);
		}
	}
}
