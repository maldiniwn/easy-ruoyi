using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.DataEncryption
{
	/// <summary>
	/// SHA256加密
	/// </summary>
	public static class SHA256Encryption
	{
		/// <summary>
		/// 字符串机密
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string Encrypt(string input)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input.Trim()));
				return ToSHA256String(bytes);
			}
		}

		/// <summary>
		/// stream机密
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static string Encrypt(Stream stream)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(stream);
				return ToSHA256String(bytes);
			}
		}

		/// <summary>
		/// 加密
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		private static string ToSHA256String(byte[] bytes)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				builder.Append(bytes[i].ToString("x2"));
			}
			return builder.ToString();
		}
	}
}
