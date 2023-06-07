using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Entities.Entities;
using System.Text;
using System.Web;

namespace EasyRuoyi.Application.Services.SysFileService
{
	/// <summary>
	/// 文件信息服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "SysFile", Order = 1)]
	[Route("sysfile")]
	public class SysFileService : ISysFileService, IDynamicApiController, ITransient
	{
		private readonly IRepository<SysFile> repSysFile;

		/// <summary>
		/// SysFileService
		/// </summary>
		/// <param name="repSysFile"></param>
		public SysFileService(IRepository<SysFile> repSysFile)
		{
			this.repSysFile = repSysFile;
		}

		/// <summary>
		/// 下载导入错误提示excel文件
		/// </summary>
		/// <param name="id">文件id</param>
		/// <returns></returns>
		[HttpGet("downloadimporterrorfile")]
		public async Task<FileResult> DownloadImportErrorFile(Guid id)
		{
			SysFile sysFile = await this.repSysFile.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == id);
			//labeling 错误提示文件
			string labelingFilePath = Path.Combine(App.HostEnvironment.ContentRootPath, "wwwroot", sysFile.FilePath, $"{sysFile.Id}_Error{sysFile.FileSuffix}");

			if (!File.Exists(labelingFilePath))
			{
				throw "错误提示文件不存在！".Ex();
			}

			// 文件名称
			var fileOriginName = sysFile.FileOriginName.Substring(0, sysFile.FileOriginName.LastIndexOf("."));
			var fileName = HttpUtility.UrlEncode($"{fileOriginName}_Error", Encoding.GetEncoding("UTF-8")) + $".xlsx";
			FileStream fs = new FileStream(labelingFilePath, FileMode.Open, FileAccess.Read);

			return await Task.FromResult(
			   new FileStreamResult(fs, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
			   {
				   FileDownloadName = fileName
			   });
		}
	}
}
