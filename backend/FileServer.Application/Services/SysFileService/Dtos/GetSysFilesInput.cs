using System;
using System.ComponentModel.DataAnnotations;

namespace FileServer.Application.Services.SysFileService.Dtos
{
	/// <summary>
	/// 查询文件列表input
	/// </summary>
	public class GetSysFilesInput
	{
		/// <summary>
		/// 文件Id
		/// </summary>
		[Required(ErrorMessage = "文件Id不能为空")]
		public Guid[] Ids { get; set; }
	}
}
