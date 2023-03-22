using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrdEditor.V3Lib
{
    public class Utils
    {
		// Annoyingly, there's no easy way to read a null-terminated ASCII string in .NET
		// (or maybe I'm just a moron), so we have to do it manually.
		public static string ReadNullTerminatedString(ref BinaryReader reader, Encoding encoding)
		{
			int bytesPerChar = encoding.GetByteCount("\0");

			List<byte> charData = new List<byte>();
			while (true)
			{
				List<byte> charBytes = new List<byte>();
				charBytes.AddRange(reader.ReadBytes(bytesPerChar));

				// If all bytes are zero, it's a null terminator
				if (charBytes.All((byte b) => b == 0))
				{
					break;
				}

				charData.AddRange(charBytes);
			}
			string result = encoding.GetString(charData.ToArray());
			return result;
		}

		public static byte[] SwapEndian(byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }
    }
}
