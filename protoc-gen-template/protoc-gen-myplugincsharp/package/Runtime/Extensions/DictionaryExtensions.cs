using System.Collections;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Dictionaryの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static class DictionaryExtensions
{
	public static string ToKeyValueString<T, V>(this Dictionary<T, V> self)
	{
		var result = new StringBuilder();
		self.ForEach(aPair => result.Append(aPair.Key + "=" + aPair.Value + "\n"));
		return result.ToString();
	}

	public static bool ContainsKeyAndData<K, V>(this Dictionary<K, V> self, K key)
	{
		if (self.ContainsKey(key) && (self[key] != null)) {
			if (self[key] is ICollection) {
				return ((ICollection)self[key]).Count > 0;
			} else {
				return true;
			}
		} else {
			return false;
		}
	}

	public static bool ContainsKey<K, V>(this Dictionary<K, V> self, K key)
	{
		if (self.ContainsKey(key) && (self[key] != null)) {
			return true;
		} else {
			return false;
		}
	}

	public static V GetValueOrDefault<K, V>(
		this Dictionary<K, V> self,
		K key,
		V defaultVal = default)
	{
		var found = self.TryGetValue(key, out var ret);
		return (found && (ret != null)) ? ret : defaultVal;
	}
}
