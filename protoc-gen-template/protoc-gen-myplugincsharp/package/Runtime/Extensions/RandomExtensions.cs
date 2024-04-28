using System;

public static class RandomExtensions
{
	public static long NextLong(this Random self, long min, long max)
	{
		var buf = new byte[sizeof(ulong)];
		self.NextBytes(buf);
		ulong n = BitConverter.ToUInt64(buf, 0);

		// Scale to between 0 inclusive and 1 exclusive; i.e. [0,1). 
		double normalised = n / (ulong.MaxValue + 1.0);

		// Determine result by scaling range and adding minimum. 
		double range = (double)max - min;

		var result = (long)(normalised * range) + min;
		return result;
	}

	public static ulong NextULong(this Random self, ulong min, ulong max)
	{
		var buf = new byte[sizeof(ulong)];
		self.NextBytes(buf);
		ulong n = BitConverter.ToUInt64(buf, 0);

		// Scale to between 0 inclusive and 1 exclusive; i.e. [0,1). 
		double normalised = n / (ulong.MaxValue + 1.0);

		// Determine result by scaling range and adding minimum. 
		double range = (double)max - min;

		var result = (ulong)(normalised * range) + min;
		return result;
	}
}