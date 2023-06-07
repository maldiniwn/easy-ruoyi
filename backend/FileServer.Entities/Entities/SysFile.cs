using EasyRuoyi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileServer.Entities.Entities
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
		/// 文件大小（单位是字节）
		/// </summary>
		[Comment("文件大小byte")]
		public long FileSize { get; set; }

		/// <summary>
		/// 两个文件的大小和散列值（SHA256）都相同的概率非常小。因此只要大小和SHA256相同，就认为是相同的文件。
		/// SHA256的碰撞的概率比MD5低很多。
		/// </summary>
		[Comment("文件SHA256哈希")]
		[Column(TypeName = "varchar")]
		[MaxLength(64)]
		public string FileSHA256Hash { get; set; }

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
