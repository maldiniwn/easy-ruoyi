using EasyRuoyi.Application.Services.RoleService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Const;
using EasyRuoyi.Core.Enums;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Utils;
using EasyRuoyi.Entities.Entities;
using Furion.DatabaseAccessor.Extensions;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Core.Models;
using Magicodes.ExporterAndImporter.Excel;
using System.Text;
using System.Web;

namespace EasyRuoyi.Application.Services.RoleService
{
	/// <summary>
	/// 角色服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "Role", Order = 1)]
	[Route("role")]
	public class RoleService : IRoleService, IDynamicApiController, ITransient
	{
		private readonly IRepository<Role> repRole;

		public RoleService(IRepository<Role> repRole)
		{
			this.repRole = repRole;
		}

		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("page")]
		public async Task<PageResult<RoleDto>> Page([FromQuery] PageRoleInput input)
		{
			var pagedList = await this.repRole.DetachedEntities.Query().Where(!string.IsNullOrWhiteSpace(input.Name), a => a.Name.Contains(input.Name))
																		.Where(!string.IsNullOrWhiteSpace(input.RoleCode), a => a.RoleCode.Contains(input.RoleCode))
																		.OrderByDescending(a => a.CreatedTime)
																		.ToPagedListAsync(input.PageIndex, input.PageSize);
			var result = XnPageResult<Role>.PageResult<RoleDto>(pagedList);
			return result;
		}

		/// <summary>
		/// 所有角色列表
		/// </summary>
		/// <returns></returns>
		[HttpGet("list")]
		public async Task<IList<RoleDto>> List()
		{
			var list = await this.repRole.DetachedEntities.OrderBy(a => a.Name).ToListAsync();
			List<RoleDto> results = list.Adapt<List<RoleDto>>();
			return results;
		}

		/// <summary>
		/// 详情
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("detail")]
		public async Task<RoleDto> Detail([FromQuery] DetailRoleInput input)
		{
			var entity = await this.repRole.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == input.Id);
			var result = entity.Adapt<RoleDto>();
			return result;
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("add")]
		[UnitOfWork]
		public async Task Add(AddRoleInput input)
		{
			var role = input.Adapt<Role>();

			//name、roleCode判重
			var exists = await this.repRole.DetachedEntities.Query().AnyAsync(a => a.Name == role.Name);
			if (exists)
			{
				throw $"角色名称【{role.Name}】已存在！".Ex();
			}

			exists = await this.repRole.DetachedEntities.Query().AnyAsync(a => a.RoleCode == role.RoleCode);
			if (exists)
			{
				throw $"角色编号【{role.RoleCode}】已存在！".Ex();
			}

			await this.repRole.InsertAsync(role);
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("edit")]
		[UnitOfWork]
		public async Task Edit(UpdateRoleInput input)
		{
			var role = input.Adapt<Role>();
			await this.repRole.UpdateAsync(role);
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("delete")]
		[UnitOfWork]
		public async Task Delete(DeleteRoleInput input)
		{
			var role = await this.repRole.SingleOrDefaultAsync(a => a.Id == input.Id);
			if (role != null)
			{
				await this.repRole.SoftDeleteAsync(role);
			}
		}

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("batchdelete")]
		[UnitOfWork]
		public async Task BatchDelete(BatchDeleteRoleInput input)
		{
			await this.repRole.SoftDeleteAsync(input.Ids);
		}

		/// <summary>
		/// 下载导入模板
		/// </summary>
		/// <returns></returns>
		[HttpGet("downloadtemplate")]
		public async Task<FileResult> DownloadTemplate()
		{
			// 创建Excel导入对象
			IImporter importer = new ExcelImporter();
			var byteArray = await importer.GenerateTemplateBytes<RoleImport>();
			// 文件名称
			var fileName = HttpUtility.UrlEncode("角色导入模板", Encoding.GetEncoding("UTF-8")) + ".xlsx";

			return await Task.FromResult(
			   new FileContentResult(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
			   {
				   FileDownloadName = fileName
			   });
		}

		/// <summary>
		/// 导入
		/// </summary>
		/// <param name="file">文件</param>
		/// <param name="updateSupport">是否更新重复数据</param>
		/// <returns></returns>
		[HttpPost("import")]
		[UnitOfWork]
		public async Task<ResultModel> Import(IFormFile file, bool updateSupport = false)
		{
			//下载导入文件到本地
			var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
			var originalFilename = file.FileName; // 文件原始名称
			var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀

			//文件信息
			var sysFile = new SysFile
			{
				Id = GuidUtil.Create(),
				FileOriginName = originalFilename,
				FileSuffix = fileSuffix,
				FileSizeKb = fileSizeKb.ToString(),
				FilePath = $"{App.Configuration["UploadFile:Default:Path"]}/{DateTime.Today.ToString("yyyyMMdd")}"
			};
			sysFile.FileObjectName = $"{sysFile.Id}{fileSuffix}";
			await sysFile.InsertAsync();

			//目录
			string dirPath = Path.Combine(App.HostEnvironment.ContentRootPath, "wwwroot", sysFile.FilePath);
			if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

			//保存文件
			string filePath = Path.Combine(dirPath, sysFile.FileObjectName);
			using (var fileStream = File.Create(filePath))
			{
				await file.CopyToAsync(fileStream);
			}

			//读取导入文件，验证数据。如果验证失败，从客户端自动发送请求，下载验证失败的文件；如果验证成功，提示上传成功
			string labelingFilePath = Path.Combine(dirPath, $"{sysFile.Id}_Error{fileSuffix}");     //labeling 错误提示文件
			IImporter importer = new ExcelImporter();
			ImportResult<RoleImport> importResult = null;

			try
			{
				importResult = await importer.Import<RoleImport>(filePath, labelingFilePath, (r) =>
				{
					//导入的角色名称、编号。用于判重
					List<string> importNames = new List<string>();
					List<string> importRoleCodes = new List<string>();
					int rowNum = 2;
					foreach (var item in r.Data)
					{
						DataRowErrorInfo drei = new DataRowErrorInfo
						{
							RowIndex = rowNum
						};

						//角色名称唯一
						bool exists = importNames.Any(a => a == item.Name);
						if (exists)
						{
							drei.FieldErrors.Add("名称", "导入数据的角色名称重复");
						}

						exists = this.repRole.DetachedEntities.Query().Any(a => a.Name == item.Name);
						if (exists)
						{
							drei.FieldErrors.Add("名称", "角色名称已存在，不能重复");
						}
						importNames.Add(item.Name);

						//角色编号唯一
						exists = importRoleCodes.Any(a => a == item.RoleCode);
						if (exists)
						{
							drei.FieldErrors.Add("角色编号", "导入数据的角色编号重复");
						}

						exists = this.repRole.DetachedEntities.Query().Any(a => a.RoleCode == item.RoleCode);
						if (exists)
						{
							drei.FieldErrors.Add("角色编号", "角色编号已存在，不能重复");
						}
						importRoleCodes.Add(item.RoleCode);

						if (drei.FieldErrors.Count > 0) r.RowErrors.Add(drei);

						rowNum++;
					}

					return r;
				});
			}
			catch
			{
				throw "导入模版解析异常！请导入正确的模板！".Ex();
			}

			if (null == importResult || null == importResult.Data) throw "导入模版解析异常！请导入正确的模板！".Ex();

			if (importResult.Data.Count == 0) throw ("模板数据为空！").Ex();

			if (importResult.Exception != null) throw ("导入异常：" + importResult.Exception).Ex();

			if (importResult.RowErrors.Count > 0) return new ResultModel { Code = (int)ErrorCode.extras, Message = "导入数据有错误！请在下载的文件中查看！", Data = $"{sysFile.Id}" };

			Guid userId = Guid.Parse(App.User?.FindFirst(ClaimConst.CLAINM_USERID)?.Value);
			List<Role> roles = new List<Role>();
			foreach (var item in importResult.Data)
			{
				var entity = item.Adapt<Role>();
				entity.Id = GuidUtil.Create();

				roles.Add(entity);
			}
			await this.repRole.InsertAsync(roles);

			return new ResultModel { Code = 200, Message = $"成功导入{roles.Count}条数据！" };
		}

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("export")]
		public async Task<FileResult> Export([FromQuery] PageRoleInput input)
		{
			input.PageIndex = 1;
			input.PageSize = int.MaxValue; //导出需要导出全部
			var entities = await Page(input);

			//导出模板路径
			var tplPath = Path.Combine(Directory.GetCurrentDirectory(), "ExportTemplates", "RoleTemplate.xlsx");

			//导出文件的byte[]
			byte[] byteArray;

			//判断是否有导出模板。如果模板存在，根据模板导出；否则，默认方式导出
			if (File.Exists(tplPath))
			{
				//创建模板对象
				RoleExportDto<RoleDto> data = new RoleExportDto<RoleDto>() { Name = "角色" };
				data.Roles = entities.Rows.ToList();
				//创建Excel导出对象
				IExportFileByTemplate exporter = new ExcelExporter();
				//导出文件
				byteArray = await exporter.ExportBytesByTemplate<RoleExportDto<RoleDto>>(data, tplPath);
			}
			else
			{
				// 创建Excel导出对象
				IExporter exporter = new ExcelExporter();
				// 导出文件
				byteArray = await exporter.ExportAsByteArray(entities.Rows);
			}

			// 文件名称
			var fileName = HttpUtility.UrlEncode("角色列表", Encoding.GetEncoding("UTF-8")) + ".xlsx";

			return await Task.FromResult(
				new FileContentResult(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
				{
					FileDownloadName = fileName
				});
		}
	}
}
