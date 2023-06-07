using EasyRuoyi.Application.Services.RoleMenuService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleMenuService
{
	/// <summary>
	/// 角色菜单服务
	/// </summary>
	public interface IRoleMenuService
	{
		/// <summary>
		/// 查询角色菜单id列表
		/// </summary>
		/// <param name="roleId">角色id</param>
		/// <returns></returns>
		Task<IList<Guid>> GetRoleMenus(Guid roleId);

		/// <summary>
		/// 保存角色菜单
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Save(RoleMenuSaveInput input);
	}
}
