using EasyRuoyi.Application.Services.MenuService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Utils;
using EasyRuoyi.Entities.Entities;
using EasyRuoyi.Entities.Enums;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System.Text;
using System.Web;

namespace EasyRuoyi.Application.Services.MenuService
{
	/// <summary>
	/// 菜单服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "Menu", Order = 1)]
	[Route("menu")]
	public class MenuService : IMenuService, IDynamicApiController, ITransient
	{
		private readonly IRepository<Menu> repMenu;

		public MenuService(IRepository<Menu> repMenu)
		{
			this.repMenu = repMenu;
		}

		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("page")]
		public async Task<PageResult<MenuPageDto>> Page([FromQuery] PageMenuInput input)
		{
			var page = await this.repMenu.DetachedEntities.Query().Where(a=>a.PId == null)
																.Where(!string.IsNullOrWhiteSpace(input.Name), a => a.Name.Contains(input.Name))
																.Where(input.IsEnable.HasValue, a => a.IsEnable == input.IsEnable)
																.OrderBy(a => a.Sort)
																.ToPagedListAsync(input.PageIndex, input.PageSize);

			var result = XnPageResult<Menu>.PageResult<MenuPageDto>(page);
			await this.DtoMapper(result.Rows);

			return result;
		}

		/// <summary>
		/// 详情
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("detail")]
		public async Task<MenuDto> Detail([FromQuery] DetailMenuInput input)
		{
			var menu = await this.repMenu.DetachedEntities.FirstOrDefaultAsync(a => a.Id == input.Id);
			var result = menu.Adapt<MenuDto>();

			var enumMenuTypes = EnumUtil.GetEnumItems(typeof(EnumMenuType));
			result.EnumMenuTypeStr = enumMenuTypes.FirstOrDefault(a => a.Value == (int)result.EnumMenuType)?.Label;

			if (menu.PId.HasValue)
			{
				var parent = await this.repMenu.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == result.PId);
				result.PName = parent?.Name;
			}

			return result;
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("add")]
		[UnitOfWork]
		public async Task Add(AddMenuInput input) 
		{
			//同一级别，Name、PermissionCode 不能重复
			bool exists = await this.repMenu.DetachedEntities.Query().AnyAsync(a => a.PId == input.PId && a.Name == input.Name);
			if (exists) 
			{
				throw $"菜单名称【{input.Name}】已存在！不能重复！".Ex();
			}

			exists = await this.repMenu.DetachedEntities.Query().AnyAsync(a => a.PId == input.PId && a.PermissionCode == input.PermissionCode);
			if (exists)
			{
				throw $"权限标识【{input.PermissionCode}】已存在！不能重复！".Ex();
			}

			Menu menu = input.Adapt<Menu>();

			//FullPath
			Menu parent = await this.repMenu.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == input.PId);
			menu.FullPath = parent == null ? $"{menu.Name}/" : $"{parent.FullPath}{menu.Name}/";

			await this.repMenu.InsertAsync(menu);
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("edit")]
		[UnitOfWork]
		public async Task Edit(UpdateMenuInput input)
		{
			//同一级别，Name、PermissionCode 不能重复，排除自己
			bool exists = await this.repMenu.DetachedEntities.Query().AnyAsync(a => a.PId == input.PId && a.Name == input.Name && a.Id != input.Id);
			if (exists)
			{
				throw $"菜单名称【{input.Name}】已存在！不能重复！".Ex();
			}

			exists = await this.repMenu.DetachedEntities.Query().AnyAsync(a => a.PId == input.PId && a.PermissionCode == input.PermissionCode && a.Id != input.Id);
			if (exists)
			{
				throw $"权限标识【{input.PermissionCode}】已存在！不能重复！".Ex();
			}

			Menu menu = input.Adapt<Menu>();

			//FullPath
			Menu old = await this.repMenu.DetachedEntities.FirstOrDefaultAsync(a => a.Id == input.Id);
			if (menu.Name != old.Name)
			{ 
				Menu parent = await this.repMenu.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == input.PId);
				menu.FullPath = parent == null ? $"{menu.Name}/" : $"{parent.FullPath}{menu.Name}/";

				//更新子节点的FullPath
				await this.repMenu.Entities.Where(a => a.FullPath.StartsWith(old.FullPath) && a.Id != old.Id)
											.ExecuteUpdateAsync(s => s.SetProperty(b => b.FullPath, b => b.FullPath.Replace(old.FullPath, menu.FullPath)));										
			}

			await this.repMenu.UpdateAsync(menu);
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("delete")]
		[UnitOfWork]
		public async Task Delete(DeleteMenuInput input)
		{
			var menu = await this.repMenu.SingleOrDefaultAsync(a => a.Id == input.Id);
			if (menu != null)
			{
				await this.repMenu.SoftDeleteAsync(menu);
			}
		}

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("batchdelete")]
		[UnitOfWork]
		public async Task BatchDelete(BatchDeleteMenuInput input)
		{
			await this.repMenu.SoftDeleteAsync(input.Ids);
		}

		/// <summary>
		/// 下载导入模板
		/// </summary>
		/// <returns></returns>
		[HttpGet("downloadtemplate")]
		public async Task<FileResult> DownloadTemplate()
		{
			await Task.CompletedTask;
			throw new NotImplementedException();
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
			await Task.CompletedTask;
			throw new NotImplementedException();
		}

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet("export")]
		public async Task<FileResult> Export([FromQuery] PageMenuInput input)
		{
			//查询所有符合条件的菜单
			var menus = await this.repMenu.DetachedEntities.Query().Where(!string.IsNullOrWhiteSpace(input.Name), a => a.Name.Contains(input.Name))
																.Where(input.IsEnable.HasValue, a => a.IsEnable == input.IsEnable)
																.OrderBy(a => a.Sort)
																.ToListAsync();
			List<Menu> list = new();
			var roots = menus.Where(a => a.PId == null).ToList();
			foreach (var r in roots)
			{
				list.Add(r);
				BuildExportList(list, menus, r);
			}

			var rows = list.Adapt<List<MenuDto>>();

			//导出模板路径
			var tplPath = Path.Combine(Directory.GetCurrentDirectory(), "ExportTemplates", "MenuTemplate.xlsx");

			//导出文件的byte[]
			byte[] byteArray;

			//判断是否有导出模板。如果模板存在，根据模板导出；否则，默认方式导出
			if (File.Exists(tplPath))
			{
				//创建模板对象
				MenuExportDto<MenuDto> data = new MenuExportDto<MenuDto>() { Name = "菜单" };
				data.Menus = rows;
				//创建Excel导出对象
				IExportFileByTemplate exporter = new ExcelExporter();
				//导出文件
				byteArray = await exporter.ExportBytesByTemplate<MenuExportDto<MenuDto>>(data, tplPath);
			}
			else
			{
				// 创建Excel导出对象
				IExporter exporter = new ExcelExporter();
				// 导出文件
				byteArray = await exporter.ExportAsByteArray(rows);
			}

			// 文件名称
			var fileName = HttpUtility.UrlEncode("菜单列表", Encoding.GetEncoding("UTF-8")) + ".xlsx";

			return await Task.FromResult(
				new FileContentResult(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
				{
					FileDownloadName = fileName
				});
		}

		/// <summary>
		/// 获取菜单tree结构
		/// </summary>
		/// <returns></returns>
		[HttpGet("tree")]
		public async Task<IList<MenuTreeNode>> Tree()
		{
			var nodes = await this.repMenu.DetachedEntities.Query()
													.Select(a => new MenuTreeNode
													{
														Id = a.Id,
														Name = a.Name,
														PId = a.PId,
														Sort = a.Sort,
													})
													.ToListAsync();

			var results = TreeBuildUtil<MenuTreeNode>.Build(nodes);
			return results;
		}

		/// <summary>
		/// 递归组织导出数据列表
		/// </summary>
		/// <param name="list"></param>
		/// <param name="menus"></param>
		/// <param name="menu"></param>
		private void BuildExportList(List<Menu> list, List<Menu> menus, Menu menu)
		{
			var children = menus.Where(a => a.PId == menu.Id).ToList();
			list.AddRange(children);

			foreach (var item in children)
			{
				this.BuildExportList(list, menus, item);
			}
		}

		/// <summary>
		/// 组织MenuPageDto
		/// </summary>
		/// <param name="rows"></param>
		/// <returns></returns>
		private async Task DtoMapper(ICollection<MenuPageDto> rows)
		{
			//获取所有菜单，准备组织每个菜单的Children
			var menus = await this.repMenu.DetachedEntities.Query().ToListAsync();
			foreach (var row in rows)
			{
				this.BuildMenuChildren(menus, row);
			}
		}

		/// <summary>
		/// 递归获取MenuPageDto.Children
		/// </summary>
		/// <param name="menus"></param>
		/// <param name="dto"></param>
		private void BuildMenuChildren(List<Menu> menus, MenuPageDto dto)
		{
			var children = menus.Where(a => a.PId == dto.Id).OrderBy(a => a.Sort).ToList();
			if(children.Count>0) 
			{
				dto.Children = children.Adapt<List<MenuPageDto>>();
				foreach (var item in dto.Children)
				{
					this.BuildMenuChildren(menus, item);
				}
			}
		}
	}
}
