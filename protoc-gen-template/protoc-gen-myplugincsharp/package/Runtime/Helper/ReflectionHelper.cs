using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// リフレクション関連処理のヘルパークラス.
/// </summary>
public class ReflectionHelper
{
	/// <summary>
	/// typeで指定したクラスまたはインターフェースを継承、実装したクラスの
	/// 実クラスリストを作成する.
	/// </summary>
	public static List<Type> GetConcreteClassList(Type type)
	{
		// 全アセンブリリストを取得する.
		var assemblys = AppDomain.CurrentDomain.GetAssemblies();
		// 全型リストを取得する.
		var typeEnumerable = assemblys.SelectMany(aAssembly => aAssembly.GetTypes());
		// typeで指定したクラスまたはインターフェースを継承、実装したクラスの実クラスリストを作成.
		List<Type> result = typeEnumerable.Where(aType => {
			return type.IsAssignableFrom(aType) && aType.IsClass && !aType.IsAbstract;
		}).ToList();

		return result;
	}

	/// <summary>
	/// Tで指定したクラスまたはインターフェースを継承、実装したクラスの
	/// デフォルトコンストラクタで生成したインスタンスのリストを作成する.
	/// </summary>
	public static List<T> GetConcreteClassInstanceList<T>()
	{
		List<Type> typeList = GetConcreteClassList(typeof(T));
		var result = typeList.Select(aType => (T)aType.GetConstructor(Type.EmptyTypes).Invoke(null)).ToList();
		return result as List<T>;
	}
}
