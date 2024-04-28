using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// IListの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static partial class IListExtensions
{
	/// <summary>
	/// このIListがnullもしくは空であるかを返却する.
	/// </summary>
	public static bool IsNullOrEmpty<T>(this IList<T> self)
		=> self == null || self.Count == 0;

	/// <summary>
	/// このIListが空であるかを返却する.
	/// </summary>
	public static bool IsEmpty<T>(this IList<T> self)
		=> self.Count == 0;


	/// <summary>
	/// このリストに関して、indexを指定した要素を取得できるか.
	/// </summary>
	public static bool IsValidIndex<T>(this IList<T> self, int index)
		=> !self.IsNullOrEmpty() && (0 <= index) && (index < self.Count);

	/// <summary>
	/// .
	/// </summary>
	public static int ToValidIndex<T>(this IList<T> self, int index)
		=> MathEx.Clamp(index, 0, self.Count);

	/// <summary>
	/// indexを0以上 count未満にClampしたインデックスの要素を取得する.
	/// </summary>
	public static T SafeGet<T>(this IList<T> self, int index)
		=> (self.Count > 0) ? self[self.ToValidIndex(index)] : default(T);

	public static int GetRoundedIndex<T>(this IList<T> self, int index)
		=> MathEx.Mod(index, self.Count);

	/// <summary>
	/// indexをcountで割った余りの値をインデックスとして値を取得する.
	/// </summary>
	public static T GetByRoundedIndex<T>(this IList<T> self, int index)
	{
		if (self.IsNullOrEmpty()) { return default(T); }
		return self[self.GetRoundedIndex(index)];
	}

	/// <summary>
	/// indexをcountで割った余りの値をインデックスとして値を取り出す.
	/// 取り出した要素はリストから削除される.
	/// </summary>
	public static T GetAndRemoveByRoundedIndex<T>(this IList<T> self, int index)
	{
		T result = self.GetByRoundedIndex(index);
		self.Remove(result);
		return result;
	}

	private static Random random = new Random();

	public static T GetByRandom<T>(this IList<T> self)
		=> self.GetByRoundedIndex(random.Next());

	public static T GetAndRemoveByRandom<T>(this IList<T> self)
	{
		T result = self.GetByRandom();
		self.Remove(result);
		return result;
	}

	public static string ToCSV<T>(this IList<T> self, char delimiter = ',')
	{
		var builder = new StringBuilder();
		self.ForEach(aValue => builder.Append(aValue.ToString() + delimiter));
		string result = builder.ToString().TrimEnd(delimiter);
		return result;
	}

	public static HashSet<T> ToHashSet<T>(this IList<T> self)
		=> new HashSet<T>(self);
}
