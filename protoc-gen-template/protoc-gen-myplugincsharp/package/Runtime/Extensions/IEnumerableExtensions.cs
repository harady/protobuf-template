using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// IEnumerableの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static class IEnumerableExtensions
{
	public static void ForEach<T>(
		this IEnumerable<T> self,
		Action<T> action)
	{
		IEnumerator<T> enumerator = self.GetEnumerator();
		while (enumerator.MoveNext()) {
			action.Invoke(enumerator.Current);
		}
	}

	/// <summary>
	/// 最小値を持つ要素を返します
	/// </summary>
	public static TSource FindMin<TSource, TResult>(
		this IEnumerable<TSource> self,
		Func<TSource, TResult> selector)
	{
		var min = self.Min(selector);
		return self.First(c => selector(c).Equals(min));
	}

	/// <summary>
	/// 最小値を持つ要素のリストを返します
	/// </summary>
	public static IEnumerable<TSource> FindMinAll<TSource, TResult>(
		this IEnumerable<TSource> self,
		Func<TSource, TResult> selector)
	{
		var min = self.Min(selector);
		return self.Where(c => selector(c).Equals(min));
	}

	/// <summary>
	/// 最大値を持つ要素を返します
	/// </summary>
	public static TSource FindMax<TSource, TResult>(
		this IEnumerable<TSource> self,
		Func<TSource, TResult> selector)
	{
		var max = self.Max(selector);
		return self.First(c => selector(c).Equals(max));
	}

	/// <summary>
	/// 最大値を持つ要素のリストを返します
	/// </summary>
	public static IEnumerable<TSource> FindMaxAll<TSource, TResult>(
		this IEnumerable<TSource> self,
		Func<TSource, TResult> selector)
	{
		var max = self.Max(selector);
		return self.Where(c => selector(c).Equals(max));
	}


	public static HashSet<T> ToHashSet<T>(this IEnumerable<T> self)
	{
		var result = new HashSet<T>();
		self.ForEach(aValue => result.Add(aValue));
		return result;
	}
}
