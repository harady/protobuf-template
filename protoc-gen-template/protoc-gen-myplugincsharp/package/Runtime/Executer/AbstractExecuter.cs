using System.Collections.Generic;

/// <summary>
/// Enumに紐づいた処理を実行するクラスの抽象クラス.
/// </summary>
public abstract class AbstractExecuter<TEnum, TExecuter>
	where TEnum : struct
	where TExecuter : AbstractExecuter<TEnum, TExecuter>
{
	/// <summary>
	/// TypeとExecuterの対応を紐付けるディクショナリ.
	/// </summary>
	private static Dictionary<TEnum, TExecuter> _typeExecuterDict = null;

	protected static Dictionary<TEnum, TExecuter> typeExecuterDict {
		get {
			if (_typeExecuterDict == null) {
				_typeExecuterDict = new Dictionary<TEnum, TExecuter>();
				var executerList 
					= ReflectionHelper.GetConcreteClassInstanceList<TExecuter>();
				executerList.ForEach(aExecuter => {
					_typeExecuterDict[aExecuter.type] = aExecuter;
				});
			}
			return _typeExecuterDict;
		}
	}

	public static void WarmUp()
	{
		var tmp = typeExecuterDict;
	}

	public static TExecuter GetExecuter(TEnum type)
	{
		return typeExecuterDict[type];
	}

	public abstract TEnum type { get; }
}
