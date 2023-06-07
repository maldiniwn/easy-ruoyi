using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.SysFileService
{
	/// <summary>
	/// 文件信息服务
	/// </summary>
	public interface ISysFileService
	{
		/// <summary>
		/// 下载导入错误提示excel文件
		/// </summary>
		/// <param name="id">文件id</param>
		/// <returns></returns>
		Task<FileResult> DownloadImportErrorFile(Guid id);
	}
}
