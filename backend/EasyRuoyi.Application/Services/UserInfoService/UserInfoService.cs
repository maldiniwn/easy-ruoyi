using EasyRuoyi.Application.RemoteServices.FileServerRemoteService;
using EasyRuoyi.Application.Services.UserInfoService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Const;
using EasyRuoyi.Core.DataEncryption.Extensions;
using EasyRuoyi.Core.Enums;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Utils;
using EasyRuoyi.Entities.Entities;
using Furion.DatabaseAccessor.Extensions;
using Furion.RemoteRequest.Extensions;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Core.Models;
using Magicodes.ExporterAndImporter.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Web;

namespace EasyRuoyi.Application.Services.UserInfoService
{
	/// <summary>
	/// 用户服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "UserInfo", Order = 1)]
	[Route("userinfo")]
	public class UserInfoService : IUserInfoService, IDynamicApiController, ITransient
	{
		private readonly IRepository<UserInfo> repUserInfo;
		private readonly IRepository<Employee> repEmployee;
		private readonly IFileServerRemoteService fileServerRemoteService;

		/// <summary>
		/// UserInfoService
		/// </summary>
		public UserInfoService(IRepository<UserInfo> repUserInfo
							, IRepository<Employee> repEmployee
							, IFileServerRemoteService fileServerRemoteService)
		{
			this.repUserInfo = repUserInfo;
			this.repEmployee = repEmployee;
			this.fileServerRemoteService = fileServerRemoteService;
		}

		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("page")]
		public async Task<PageResult<UserInfoDto>> Page([FromQuery] PageUserInfoInput input)
		{
			var userinfos = this.repUserInfo.DetachedEntities.Query()
										.Where(!string.IsNullOrWhiteSpace(input.UserName), a => a.UserName.Contains(input.UserName))
										.Where(input.IsEnable.HasValue, a => a.IsEnable == input.IsEnable);
			var employees = this.repEmployee.DetachedEntities
										.Where(!string.IsNullOrWhiteSpace(input.Name), a => a.Name.Contains(input.Name));

			var query = from u in userinfos
						join emp in employees on u.EmployeeId equals emp.Id
						orderby u.CreatedTime descending
						select new UserInfoDto
						{
							Id = u.Id,
							UserName = u.UserName,
							EmployeeId = u.EmployeeId,
							Name = emp.Name,
							EnumGender = emp.EnumGender,
							IsEnable = u.IsEnable,
							Tel = emp.Tel,
							SID = emp.SID,
							BornDate = emp.BornDate,
							CreatedUserName = u.CreatedUserName,
							CreatedTime = u.CreatedTime,
							UpdatedUserName = u.UpdatedUserName,
							UpdatedTime = u.UpdatedTime,
						};

			var pagedList = await query.ToPagedListAsync();
			var result = XnPageResult<UserInfoDto>.PageResult<UserInfoDto>(pagedList);
			this.DtoMapper(result.Rows);

			return result;
		}

		/// <summary>
		/// 详情
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("detail")]
		public async Task<UserInfoDto> Detail([FromQuery] DetailUserInfoInput input)
		{
			var list = await this.repUserInfo.DetachedEntities
									.Where(a => a.Id == input.Id)
									.Select(a => new UserInfoDto
									{
										Id = a.Id,
										UserName = a.UserName,
										EmployeeId = a.EmployeeId,
										Name = a.Employee.Name,
										EnumGender = a.Employee.EnumGender,
										IsEnable = a.IsEnable,
										Tel = a.Employee.Tel,
										SID = a.Employee.SID,
										BornDate = a.Employee.BornDate,
										HeadUrl = a.Employee.HeadUrl,
										CreatedUserName = a.CreatedUserName,
										CreatedTime = a.CreatedTime,
										UpdatedUserName = a.UpdatedUserName,
										UpdatedTime = a.UpdatedTime,
									})
									.ToListAsync();

			if (list.Count > 0)
			{
				this.DtoMapper(list);

				UserInfoDto result = list[0];
				//把图片转换成前端显示要求的格式
				if (!string.IsNullOrWhiteSpace(result.HeadUrl))
				{
					var ids = JsonConvert.DeserializeObject<Guid[]>(result.HeadUrl);
					result.HeadUrl = await this.fileServerRemoteService.GetSysFiles(ids);					
				}

				return result;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("add")]
		[UnitOfWork]
		public async Task Add(AddUserInfoInput input)
		{
			//用户名唯一
			bool exists = await this.repUserInfo.DetachedEntities.Query().AnyAsync(a => a.UserName == input.UserName);
			if (exists)
			{
				throw $"用户名【{input.UserName}】已存在，不能重复！".Ex();
			}

			//身份证唯一
			if (!string.IsNullOrWhiteSpace(input.SID))
			{
				exists = await this.repEmployee.DetachedEntities.Query().AnyAsync(a => a.SID == input.SID);
				if (exists)
				{
					throw $"身份证【{input.SID}】已存在，不能重复！".Ex();
				}
			}

			//组织头像数据
			if (!string.IsNullOrWhiteSpace(input.HeadUrl))
			{
				var uploadItems = JsonConvert.DeserializeObject<List<UploadItemModel>>(input.HeadUrl);
				List<Guid> uploadIds = uploadItems.Select(a => a.Id).ToList();
				input.HeadUrl = JsonConvert.SerializeObject(uploadIds);
			}

			//新增Employee
			var emp = new Employee
			{
				Id = GuidUtil.Create(),
				Name = input.Name,
				EnumGender = input.EnumGender,
				Tel = input.Tel,
				SID = input.SID,
				BornDate = input.BornDate,
				HeadUrl = input.HeadUrl,
			};
			await this.repEmployee.InsertAsync(emp);

			//新增UserInfo
			var userinfo = new UserInfo
			{
				Id = emp.Id,
				UserName = input.UserName,
				Password = "888888".ToSHA256Encryp(),
				EmployeeId = emp.Id,
				IsEnable = true,
			};
			await this.repUserInfo.InsertAsync(userinfo);
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("edit")]
		[UnitOfWork]
		public async Task Edit(UpdateUserInfoInput input)
		{
			var userinfo = await this.repUserInfo.FirstOrDefaultAsync(a=> a.Id == input.Id);
			if (null == userinfo)
			{
				throw "用户不存在！".Ex();
			}

			bool exists;
			//身份证唯一
			if (!string.IsNullOrWhiteSpace(input.SID))
			{
				exists = await this.repEmployee.DetachedEntities.Query().AnyAsync(a => a.SID == input.SID && a.Id != input.Id);
				if (exists)
				{
					throw $"身份证【{input.SID}】已存在，不能重复！".Ex();
				}
			}

			//组织头像数据
			if (!string.IsNullOrWhiteSpace(input.HeadUrl))
			{
				var uploadItems = JsonConvert.DeserializeObject<List<UploadItemModel>>(input.HeadUrl);
				List<Guid> uploadIds = uploadItems.Select(a => a.Id).ToList();
				input.HeadUrl = JsonConvert.SerializeObject(uploadIds);
			}

			//更新
			userinfo.IsEnable = input.IsEnable;
			await this.repUserInfo.UpdateAsync(userinfo);

			Employee employee = await this.repEmployee.FirstOrDefaultAsync(a => a.Id == userinfo.EmployeeId);
			employee.Name = input.Name;
			employee.EnumGender= input.EnumGender;
			employee.Tel = input.Tel;
			employee.SID = input.SID;
			employee.BornDate = input.BornDate;
			employee.HeadUrl = input.HeadUrl;
			await this.repEmployee.UpdateAsync(employee);
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("delete")]
		[UnitOfWork]
		public async Task Delete(DeleteUserInfoInput input)
		{
			var userinfo = await this.repUserInfo.FirstOrDefaultAsync(a => a.Id == input.Id);
			if (userinfo != null) 
			{
				await this.repUserInfo.SoftDeleteAsync(userinfo);
			}
		}

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("batchdelete")]
		[UnitOfWork]
		public async Task BatchDelete(BatchDeleteUserInfoInput input)
		{
			await this.repUserInfo.SoftDeleteAsync(input.Ids);
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
			var byteArray = await importer.GenerateTemplateBytes<UserInfoImport>();
			// 文件名称
			var fileName = HttpUtility.UrlEncode("用户导入模板", Encoding.GetEncoding("UTF-8")) + ".xlsx";

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
			ImportResult<UserInfoImport> importResult = null;

			try
			{
				importResult = await importer.Import<UserInfoImport>(filePath, labelingFilePath, (r) =>
				{
					//导入的用户名、身份证。用于判重
					List<string> importUserNames = new List<string>();
					List<string> importSIDs = new List<string>();
					int rowNum = 2;
					foreach (var item in r.Data)
					{
						DataRowErrorInfo drei = new DataRowErrorInfo
						{
							RowIndex = rowNum
						};

						//用户名唯一
						bool exists = importUserNames.Any(a => a == item.Name);
						if (exists)
						{
							drei.FieldErrors.Add("用户名", "导入数据的用户名重复");
						}

						exists = this.repUserInfo.DetachedEntities.Query().Any(a => a.UserName == item.UserName);
						if (exists)
						{
							drei.FieldErrors.Add("用户名", "用户名已存在，不能重复");
						}
						importUserNames.Add(item.Name);

						//身份证唯一
						if (!string.IsNullOrWhiteSpace(item.SID))
						{ 
							exists = importSIDs.Any(a => a == item.SID);
							if (exists)
							{
								drei.FieldErrors.Add("身份证", "导入数据的身份证重复");
							}

							exists = this.repEmployee.DetachedEntities.Query().Any(a => a.SID == item.SID);
							if (exists)
							{
								drei.FieldErrors.Add("身份证", "身份证已存在，不能重复");
							}
							importSIDs.Add(item.SID);
						}

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
			List<Employee> employees = new List<Employee>();
			List<UserInfo> users = new List<UserInfo>();
			foreach (var item in importResult.Data)
			{
				//新增Employee
				var emp = new Employee
				{
					Id = GuidUtil.Create(),
					Name = item.Name,
					EnumGender = item.EnumGender,
					Tel = item.Tel,
					SID = item.SID,
					BornDate = item.BornDate,
				};
				employees.Add(emp);

				//新增UserInfo
				var userinfo = new UserInfo
				{
					Id = emp.Id,
					UserName = item.UserName,
					Password = "888888".ToSHA256Encryp(),
					EmployeeId = emp.Id,
					IsEnable = true,
				};
				users.Add(userinfo);
			}
			await this.repEmployee.InsertAsync(employees);
			await this.repUserInfo.InsertAsync(users);

			return new ResultModel { Code = 200, Message = $"成功导入{employees.Count}条数据！" };
		}

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("export")]
		public async Task<FileResult> Export([FromQuery] PageUserInfoInput input)
		{
			input.PageIndex = 1;
			input.PageSize = int.MaxValue; //导出需要导出全部
			var entities = await Page(input);

			//导出模板路径
			var tplPath = Path.Combine(Directory.GetCurrentDirectory(), "ExportTemplates", "UserInfoTemplate.xlsx");

			//导出文件的byte[]
			byte[] byteArray;

			//判断是否有导出模板。如果模板存在，根据模板导出；否则，默认方式导出
			if (File.Exists(tplPath))
			{
				//创建模板对象
				UserInfoExportDto<UserInfoDto> data = new UserInfoExportDto<UserInfoDto>() { Name = "用户" };
				data.UserInfos = entities.Rows.ToList();
				//创建Excel导出对象
				IExportFileByTemplate exporter = new ExcelExporter();
				//导出文件
				byteArray = await exporter.ExportBytesByTemplate<UserInfoExportDto<UserInfoDto>>(data, tplPath);
			}
			else
			{
				// 创建Excel导出对象
				IExporter exporter = new ExcelExporter();
				// 导出文件
				byteArray = await exporter.ExportAsByteArray(entities.Rows);
			}

			// 文件名称
			var fileName = HttpUtility.UrlEncode("用户列表", Encoding.GetEncoding("UTF-8")) + ".xlsx";

			return await Task.FromResult(
				new FileContentResult(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
				{
					FileDownloadName = fileName
				});
		}

		/// <summary>
		/// 组织Dto
		/// </summary>
		/// <param name="rows"></param>
		private void DtoMapper(ICollection<UserInfoDto> rows)
		{
			var enumGenderList = EnumUtil.GetEnumItems(typeof(EnumGender));

			foreach (var row in rows)
			{
				row.EnumGenderStr = enumGenderList.FirstOrDefault(a => a.Value == (int)row.EnumGender)?.Label;
			}
		}
	}
}
