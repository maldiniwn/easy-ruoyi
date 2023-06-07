using EasyRuoyi.Application.Services.MenuService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Utils;

namespace EasyRuoyi.Application.Services.MenuService
{
	/// <summary>
	/// 菜单服务
	/// </summary>
	public interface IMenuService
	{
		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<PageResult<MenuPageDto>> Page([FromQuery] PageMenuInput input);

		/// <summary>
		/// 详情
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<MenuDto> Detail([FromQuery] DetailMenuInput input);

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Add(AddMenuInput input);

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Edit(UpdateMenuInput input);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Delete(DeleteMenuInput input);

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task BatchDelete(BatchDeleteMenuInput input);

		/// <summary>
		/// 下载导入模板
		/// </summary>
		/// <returns></returns>
		Task<FileResult> DownloadTemplate();

		/// <summary>
		/// 导入
		/// </summary>
		/// <param name="file">文件</param>
		/// <param name="updateSupport">是否更新重复数据</param>
		/// <returns></returns>
		Task<ResultModel> Import(IFormFile file, bool updateSupport = false);

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<FileResult> Export([FromQuery] PageMenuInput input);

		/// <summary>
		/// 获取菜单tree结构
		/// </summary>
		/// <returns></returns>
		Task<IList<MenuTreeNode>> Tree();
	}
}
