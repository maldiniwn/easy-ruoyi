using EasyRuoyi.Application.Services.RoleService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService
{
	/// <summary>
	/// 角色服务接口
	/// </summary>
	public interface IRoleService
	{
		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<PageResult<RoleDto>> Page([FromQuery] PageRoleInput input);

		/// <summary>
		/// 所有角色列表
		/// </summary>
		/// <returns></returns>
		Task<IList<RoleDto>> List();

		/// <summary>
		/// 详情
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<RoleDto> Detail([FromQuery] DetailRoleInput input);

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Add(AddRoleInput input);

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Edit(UpdateRoleInput input);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Delete(DeleteRoleInput input);

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task BatchDelete(BatchDeleteRoleInput input);

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
		Task<FileResult> Export([FromQuery] PageRoleInput input);
	}
}
