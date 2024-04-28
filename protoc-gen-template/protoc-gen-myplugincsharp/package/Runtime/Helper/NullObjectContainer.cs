using System.Collections.Generic;

/// <summary>
/// ヌルオブジェクトを格納する.
/// </summary>
public static class NullObjectContainer
{
	private static readonly Dictionary<string, object> dict
		= new Dictionary<string, object>();

	public static T Get<T>() where T : new()
	{
		if (!dict.ContainsKey(typeof(T).FullName)) {
			dict[typeof(T).FullName] = new T();
		}
		return (T)dict[typeof(T).FullName];
	}
}
