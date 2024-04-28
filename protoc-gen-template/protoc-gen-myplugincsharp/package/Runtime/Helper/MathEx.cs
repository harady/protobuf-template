using System;

public static class MathEx
{
	/// <summary>
	/// 剰余を返却する.
	/// Mod (-3, 5) = 2
	/// Mod (3, -5) = -2
	/// Mod (-3, -5) = -3
	/// </summary>
	/// <param name="toMod">割られる数.</param>
	/// <param name="modBy">割る数.</param>
	public static int Mod(int toMod, int modBy)
	{
		int result = 0;
		if (modBy != 0) {
			result = toMod - (modBy * (int)Math.Floor((double)toMod / (double)modBy));
		}
		return result;
	}

	/// <summary>
	/// この数値を modByで割った際の剰余を返却する.
	/// </summary>
	public static int AddAndMod(int toMod, int addVal, int modBy)
	{
		return Mod(toMod + addVal, modBy);
	}

	public static int ClampToInt(long value, int min, int max)
	{
		int result = (int)Clamp(value, (long)min, (long)max);
		return result;
	}

	public static int ClampToCompareResult(long value)
	{
		int result = ClampToInt(value, -1, 1);
		return result;
	}

	/// <summary>
	/// Mathf.Clampと同じ.
	/// UnityEngine.Mathfに同じメソッドがあるが、
	/// メイン以外のスレッドで実行出来るようにここでも実装しています.
	/// </summary>
	/// <param name="value">Clampする値.</param>
	/// <param name="min">最小値.</param>
	/// <param name="max">最大値.</param>
	public static T Clamp<T>(T value, T min, T max) where T : IComparable
	{
		if (value.CompareTo(max) > 0) {
			return max;
		} else if (value.CompareTo(min) < 0) {
			return min;
		} else {
			return value;
		}
	}

	/// <summary>
	/// currentAngleで指定した角度を、
	/// targetAngleで指定した角度に向かって、
	/// addAngleで指定した角度回転する.
	/// 角度の差がaddAngle以下の場合は、targetAngleを返す
	/// </summary>
	public static float ToTargetAngle(
		float currentAngle,
		float targetAngle,
		float addAngle)
	{
		var diffAngle = RoundAnglePlMi180(targetAngle - currentAngle);

		float result = currentAngle;
		if (Math.Abs(diffAngle) <= addAngle) {
			result = targetAngle;
		} else if (diffAngle < 0) {
			result = currentAngle - addAngle;
		} else {
			result = currentAngle + addAngle;
		}

		return result;
	}


	/// <summary>
	/// angleで指定した角度を-180～180の範囲に収まるよう変換する.
	/// </summary>
	/// <returns>-180～180の範囲に収まるよう変換した角度.</returns>
	/// <param name="angle">角度(Degree).</param>
	public static float RoundAnglePlMi180(float angle)
	{
		float result = angle % 360.0f;
		if (result > 180.0f) {
			result -= 360.0f;
		} else if (result < -180.0f) {
			result += 360.0f;
		}
		return result;
	}

	/// <summary>
	/// angleで指定した角度を0～360の範囲に収まるよう変換する.
	/// </summary>
	/// <returns>0～360の範囲に収まるよう変換した角度.</returns>
	/// <param name="angle">角度(Degree).</param>
	public static float RoundAngle0To360(float angle)
	{
		float result = angle % 360.0f;
		if (result < 0) {
			result += 360.0f;
		}
		return result;
	}
}
