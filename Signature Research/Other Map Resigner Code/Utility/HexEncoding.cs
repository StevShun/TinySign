using System;
namespace Utility
{
	public class HexEncoding
	{
		public static int GetByteCount(string hexString)
		{
			int num = 0;
			for (int i = 0; i < hexString.get_Length(); i++)
			{
				char c = hexString.get_Chars(i);
				if (HexEncoding.IsHexDigit(c))
				{
					num++;
				}
			}
			if (num % 2 != 0)
			{
				num--;
			}
			return num / 2;
		}
		public static byte[] GetBytes(string hexString, out int discarded)
            // hexString var is the string of text being read from the textbox in the app
            // discarded is an integer that is being referenced from the original void
		{
			discarded = 0;
			string text = "";
			for (int i = 0; i < hexString.get_Length(); i++) // Set i = 0 // Stop if i is greater than string length
			{
				char c = hexString.get_Chars(i); // c var is declared as char and set equal to each char in the text string
				if (HexEncoding.IsHexDigit(c)) // If the char in the text string is a Hex digit...
				{
					text += c; // text = text + c
				}
				else
				{
					discarded++; // If it is not a hex digit, then add to discarded integer?
				}
			}
			if (text.get_Length() % 2 != 0) // If the text string's length has a remainder greater other than zero
			{
				discarded++; // Add to discarded integer
				text = text.Substring(0, text.get_Length() - 1); // Update text string var = starting at substring index position 0, with a total length of the substring - 1
			}
			int num = text.get_Length() / 2; // var num integer = length of text string and divides by 2
			byte[] array = new byte[num]; // Make a new array of bytes containing the amount of bytes specified by num variable
			int num2 = 0; // Make a new integer = 0
			for (int j = 0; j < array.Length; j++) // Do until j exceeds length of the array
			{
				string hex = new string(new char[] // Make a new string of chars named hex and get chars of bytes 0 and 1
				{
					text.get_Chars(num2),
					text.get_Chars(num2 + 1)
				});
				array[j] = HexEncoding.HexToByte(hex); // Turn hex into bytes for j array
				num2 += 2; // Advance position by 2?
			}
			return array; // Returns a really fucked up array
		}
		public static string ToString(byte[] bytes)
		{
			string text = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				text += bytes[i].ToString("X2");
			}
			return text;
		}
		public static bool InHexFormat(string hexString)
		{
			bool result = true;
			for (int i = 0; i < hexString.get_Length(); i++)
			{
				char c = hexString.get_Chars(i);
				if (!HexEncoding.IsHexDigit(c))
				{
					result = false;
					break;
				}
			}
			return result;
		}
		public static bool IsHexDigit(char c)
		{
			int num = Convert.ToInt32('A');
			int num2 = Convert.ToInt32('0');
			c = char.ToUpper(c);
			int num3 = Convert.ToInt32(c);
			return (num3 >= num && num3 < num + 6) || (num3 >= num2 && num3 < num2 + 10);
		}
		private static byte HexToByte(string hex)
		{
			if (hex.get_Length() > 2 || hex.get_Length() <= 0)
			{
				throw new ArgumentException("hex must be 1 or 2 characters in length");
			}
			return byte.Parse(hex, 515);
		}
	}
}
