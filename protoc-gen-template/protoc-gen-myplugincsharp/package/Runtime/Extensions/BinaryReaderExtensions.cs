using System.IO;

/// <summary>
/// BinaryReaderの汎用的な拡張メソッドを定義したクラス.
/// </summary>
public static class BinaryReaderExtensions
{
	public static byte[] ReadAllBytes(this BinaryReader self)
	{
		const int BufferSize = 4096;
		using (var memoryStream = new MemoryStream()) {
			byte[] buffer = new byte[BufferSize];
			int count;
			while ((count = self.Read(buffer, 0, buffer.Length)) != 0) {
				memoryStream.Write(buffer, 0, count);
			}
			return memoryStream.ToArray();
		}
	}
}
