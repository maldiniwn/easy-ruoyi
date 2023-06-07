using EasyRuoyi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EasyRuoyi.Entities.Entities
{
	/// <summary>
	/// 文件信息
	/// </summary>
	[Comment("文件信息")]
	public class SysFile : DEntityBase
	{
		/// <summary>
		/// 原始文件名称（上传时候的文件名）
		/// </summary>
		[Comment("原始文件名称")]
		[Required(ErrorMessage = "原始文件名称不能为空")]
		[MaxLength(512)]
		public string FileOriginName { get; set; }

		/// <summary>
		/// 文件后缀
		/// </summary>
		[Comment("文件后缀")]
		[MaxLength(50)]
		public string FileSuffix { get; set; }

		/// <summary>
		/// 文件大小kb
		/// </summary>
		[Comment("文件大小kb")]
		[MaxLength(50)]
		public string FileSizeKb { get; set; }

		/// <summary>
		/// 存储文件名称（文件唯一标识id）
		/// </summary>
		[Comment("存储文件名称")]
		[Required(ErrorMessage = "存储文件名称不能为空")]
		[MaxLength(512)]
		public string FileObjectName { get; set; }

		/// <summary>
		/// 存储路径
		/// </summary>
		[Comment("存储路径")]
		[MaxLength(512)]
		public string FilePath { get; set; }
	}
}
