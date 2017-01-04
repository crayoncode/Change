using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace 字符二进制转换
{
	public static class Change
	{

		public static string bianma(string s)
		{
			byte[] data = Encoding.Unicode.GetBytes(s);
			StringBuilder result = new StringBuilder(data.Length * 8);

			foreach (byte b in data)
			{
				result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
			}
			return result.ToString();
		}

		/// <summary>
		/// 将二进制转成字符串
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string jiema(string s)
		{
			System.Text.RegularExpressions.CaptureCollection cs =
				System.Text.RegularExpressions.Regex.Match(s, @"([01]{8})+").Groups[1].Captures;
			byte[] data = new byte[cs.Count];
			for (int i = 0; i < cs.Count; i++)
			{
				data[i] = Convert.ToByte(cs[i].Value, 2);
			}
			return Encoding.Unicode.GetString(data, 0, data.Length);
		}


		public static string EncryptString(string sInputString, string sKey)
		{
			byte[] data = System.Text.Encoding.Default.GetBytes(sInputString);
			byte[] result;
			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
			DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			ICryptoTransform desencrypt = DES.CreateEncryptor();
			result = desencrypt.TransformFinalBlock(data, 0, data.Length);

			string desString = "";
			for (int i = 0; i < result.Length; i++)
			{
				desString += result[i].ToString() + "-";
			}

			//return desString.TrimEnd('-');
			return BitConverter.ToString(result);
		}

		public static string DecryptString(string sInputString, string sKey)
		{
			string[] sInput = sInputString.Split("-".ToCharArray());
			byte[] data = new byte[sInput.Length];
			byte[] result;
			for (int i = 0; i < sInput.Length; i++)
				data[i] = byte.Parse(sInput[i], System.Globalization.NumberStyles.HexNumber);

			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
			DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			ICryptoTransform desencrypt = DES.CreateDecryptor();
			result = desencrypt.TransformFinalBlock(data, 0, data.Length);
			return System.Text.Encoding.Default.GetString(result);
		}

	}
}
