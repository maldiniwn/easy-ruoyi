using EasyRuoyi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Services.SysFileService.Dtos
{
	/// <summary>
	/// 下载文件 input
	/// </summary>
	public class DownloadInput
	{
		/// <summary>
		/// 下载文件Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }
	}
}
