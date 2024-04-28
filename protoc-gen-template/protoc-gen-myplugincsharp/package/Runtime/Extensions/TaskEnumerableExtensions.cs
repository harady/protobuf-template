using System;
using System.Collections.Generic;
using System.Threading.Tasks;


/// <summary>
/// 
/// </summary>
public static class TaskEnumerableExtensions
{
	public static Task WhenAll(this IEnumerable<Task> tasks)
		=> Task.WhenAll(tasks);

	public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
		=> Task.WhenAll(tasks);
}