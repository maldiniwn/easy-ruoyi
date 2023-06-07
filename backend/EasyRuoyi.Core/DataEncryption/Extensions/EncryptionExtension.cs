using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.DataEncryption.Extensions
{
	/// <summary>
	/// 加密扩展方法类
	/// </summary>
	public static class EncryptionExtension
	{
		/// <summary>
		/// 字符串的 SHA256 加密
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ToSHA256Encryp(this string str)
		{
			if (string.IsNullOrWhiteSpace(str)) return "";

			return SHA256Encryption.Encrypt(str);
		}

		/// <summary>
		/// 流的 SHA256 加密
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static string ToSHA256Encryp(this Stream stream)
		{
			if (null == stream) return "";

			return SHA256Encryption.Encrypt(stream);
		}
	}
}
