using Furion.DistributedIDGenerator;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EasyRuoyi.Core.Utils
{
	/// <summary>
	/// Guid工具类
	/// </summary>
	public static class GuidUtil
	{
		private static object locker = new object();

		/// <summary>
		/// 根据字符串，生成特定Guid
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static Guid Create(string key)
		{
			key = key ?? "";
			byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(key));
			Guid id = new Guid(bytes);
			return id;
		}

		/// <summary>
		/// 生成有序GUid
		/// </summary>
		/// <returns></returns>
		public static Guid Create()
		{
			lock (locker)
			{
				return IDGen.NextID();
			}
		}
	}
}
