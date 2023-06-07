using System;

namespace EasyRuoyi.Core.BusinessModel
{
	/// <summary>
	/// 上传文件模型
	/// </summary>
	public class UploadItemModel
	{
		/// <summary>
		/// Id
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// 原始文件名称（上传时候的文件名）
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 文件大小（单位是字节）
		/// </summary>
		public long Length { get; set; }

		/// <summary>
		/// 远程访问Url
		/// </summary>
		public string Url { get; set; }
	}
}
