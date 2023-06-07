using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.DataEncryption.Extensions;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Utils;
using FileServer.Application.Services.SysFileService.Dtos;
using FileServer.Entities.Entities;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileServer.Application.Services.SysFileService
{
	/// <summary>
	/// 文件服务
	/// </summary>
	[ApiDescriptionSettings("文件管理", Name = "SysFile", Order = 1)]
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
		/// 上传文件
		/// </summary>
		/// <param name="file">文件</param>
		/// <returns>上传的文件数据id</returns>
		[HttpPost("upload")]
		[UnitOfWork]
		[RequestSizeLimit(20 * 1024 * 1024)]//20M
		public async Task<UploadItemModel> Upload(IFormFile file)
		{
			//计算文件SHA256哈希
			var stream = file.OpenReadStream();
			string fileSHA256Hash = stream.ToSHA256Encryp();

			//根据 文件大小 和 SHA256哈希 查找重复文件
			SysFile sysFile = await this.repSysFile.DetachedEntities.Query().FirstOrDefaultAsync(a => a.FileSize == file.Length && a.FileSHA256Hash == fileSHA256Hash);

			SysFile entity;
			if(null == sysFile) 
			{
				//不存在重复文件
				entity = new SysFile
				{
					Id = GuidUtil.Create(),
					FileOriginName = file.FileName,
					FileSuffix = Path.GetExtension(file.FileName).ToLower(),
					FileSize = file.Length,
					FileSHA256Hash = fileSHA256Hash,
					FilePath = $"{App.Configuration["UploadFile:Default:Path"]}/{DateTime.Today.ToString("yyyyMMdd")}",
				};
				entity.FileObjectName = $"{entity.Id}{entity.FileSuffix}";

				//目录
				string dirPath = Path.Combine(App.HostEnvironment.ContentRootPath, "wwwroot", entity.FilePath);
				if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

				//保存文件
				string filePath = Path.Combine(dirPath, entity.FileObjectName);
				using var fileStream = File.Create(filePath);
				await file.CopyToAsync(fileStream);
			}
			else 
			{
				//存在重复文件，只新增数据，不上传，使用相同的上传文件
				entity = sysFile.Adapt<SysFile>();
				entity.Id = GuidUtil.Create();
				entity.FileOriginName = file.FileName;
				entity.FileSuffix = Path.GetExtension(file.FileName).ToLower();
			}

			await this.repSysFile.InsertAsync(entity);

			UploadItemModel result = new ()
			{
				Id = entity.Id,
				Name = entity.FileOriginName,
				Length = entity.FileSize,
				Url = $"{App.Configuration["ServiceConfig:FileServer:Host"].Trim('/')}/{entity.FilePath}/{entity.FileObjectName}"
			};

			return result;
		}

		/// <summary>
		/// 下载文件
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("download")]
		public async Task<FileResult> Download([FromQuery] DownloadInput input)
		{
			SysFile sysFile = await this.repSysFile.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == input.Id);
			//文件地址
			string filePath = Path.Combine(App.HostEnvironment.ContentRootPath, "wwwroot", sysFile.FilePath, sysFile.FileObjectName);

			if (!File.Exists(filePath))
			{
				throw "文件不存在！".Ex();
			}

			// 文件名称
			var fileName = HttpUtility.UrlEncode($"{sysFile.FileOriginName}", Encoding.GetEncoding("UTF-8"));
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			return new FileStreamResult(fs, "application/octet-stream") { FileDownloadName = fileName };
		}

		/// <summary>
		/// 查询文件列表。
		/// 内部服务调用，不需要鉴权
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("getSysFiles")]
		[AllowAnonymous]
		public async Task<IList<UploadItemModel>> GetSysFiles([FromQuery] GetSysFilesInput input)
		{
			var list = await this.repSysFile.DetachedEntities.Query().Where(a => input.Ids.Contains(a.Id)).ToListAsync();

			List<UploadItemModel> results = new ();
			foreach (var item in list) 
			{
				UploadItemModel f = new()
				{
					Id = item.Id,
					Name = item.FileOriginName,
					Length = item.FileSize,
					Url = $"{App.Configuration["ServiceConfig:FileServer:Host"].Trim('/')}/{item.FilePath}/{item.FileObjectName}"
				};
				results.Add(f);
			}

			return results;
		}
	}
}
