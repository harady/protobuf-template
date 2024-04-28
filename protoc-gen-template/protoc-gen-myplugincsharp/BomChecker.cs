class BomChecker
{
	public static bool HasBom(string filePath)
	{
		var bom = new byte[4];
		using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
			fs.Read(bom, 0, 4);
		}
		return IsBOM(bom, out var codepage);
	}

	private static bool IsBOM(byte[] bomByte, out int codepage)
	{
		bool result;
		byte[] bomUTF8 = { 0xEF, 0xBB, 0xBF };
		byte[] bomUTF16Little = { 0xFF, 0xFE };
		byte[] bomUTF16Big = { 0xFE, 0xFF };
		byte[] bomUTF32Little = { 0xFF, 0xFE, 0x00, 0x00 };
		byte[] bomUTF32Big = { 0x00, 0x00, 0xFE, 0xFF };

		if (IsMatched(bomByte, bomUTF8)) {
			result = true;
			codepage = 65001; //utf-8,Unicode (UTF-8)
		} else if (IsMatched(bomByte, bomUTF32Little)) {
			result = true;
			codepage = 12000; //utf-32,Unicode (UTF-32)
		} else if (IsMatched(bomByte, bomUTF32Big)) {
			result = true;
			codepage = 12001; //utf-32BE,Unicode (UTF-32 Big-Endian) 
		} else if (IsMatched(bomByte, bomUTF16Little)) {
			result = true;
			codepage = 1200; //utf-16,Unicode
		} else if (IsMatched(bomByte, bomUTF16Big)) {
			result = true;
			codepage = 1201; //utf-16BE,Unicode (Big-Endian) 
		} else {
			result = false;
			//codepage = 0; //non BOM !
			codepage = 932; //shift_jis,Japanese (Shift-JIS)
		}

		return result;
	}


	private static bool IsMatched(byte[] data, byte[] bom)
	{
		bool result = true;

		for (int i = 0; i < bom.Length; i++) {
			if (bom[i] != data[i]) {
				result = false;
				break;
			}
		}

		return result;
	}
}
