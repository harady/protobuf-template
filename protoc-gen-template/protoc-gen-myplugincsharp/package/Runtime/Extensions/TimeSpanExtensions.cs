using System;

/// <summary>
/// 
/// </summary>
public static class TimeSpanExtensions
{
	/// <summary>
	/// TimeSpanを「あと○○年」という表示形式に変換した値を返却する.
	/// </summary>
	public static string GetShortText(
		this TimeSpan self)
	{
		string result = "";
		int totalDays = (int)self.TotalDays;
		int totalHours = (int)self.TotalHours;
		int totalMinutes = (int)self.TotalMinutes;
		// 年数と月数はどんぶり勘定.
		int totalMonths = totalDays / 30;
		int totalYears = totalDays / 365;
		if (totalYears > 0) {
			result = totalYears + "年";
		} else if (totalMonths > 0) {
			result = totalMonths + "ヶ月";
		} else if (totalDays > 0) {
			result = totalDays + "日";
		} else if (totalHours > 0) {
			result = totalHours + "時間";
		} else if (totalMinutes > 0) {
			result = totalMinutes + "分";
		} else {
			result = "";
		}
		return result;
	}

	/// <summary>
	/// このTimeSpanのformatで指定した書式の文字列を取得する.
	/// </summary>
	/// <returns>このTimeSpanのformatで指定した書式の文字列.</returns>
	/// <param name="format">書式指定.</param>
	public static string ToFormatString(
		this TimeSpan self, string format = "HH:mm:ss")
	{
		string sign = (self > TimeSpan.Zero) ? "" : "-";
		TimeSpan addTime = (self > TimeSpan.Zero) ? self : -self;
		return sign + new DateTime(0).Add(addTime).ToString(format);
	}
}
