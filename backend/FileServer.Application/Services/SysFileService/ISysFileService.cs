using EasyRuoyi.Core.BusinessModel;
using FileServer.Application.Services.SysFileService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServer.Application.Services.SysFileService
{
	/// <summary>
	/// 文件服务
	/// </summary>
	public interface ISysFileService
	{
		/// <summary>
		/// 上传文件
		/// </summary>
		/// <param name="file">文件</param>
		/// <returns>上传的文件数据id</returns>
		Task<UploadItemModel> Upload(IFormFile file);

		/// <summary>
		/// 下载文件
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<FileResult> Download([FromQuery]DownloadInput input);

		/// <summary>
		/// 查询文件列表。
		/// 内部服务调用，不需要鉴权
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<IList<UploadItemModel>> GetSysFiles([FromQuery]GetSysFilesInput input);
	}
}
