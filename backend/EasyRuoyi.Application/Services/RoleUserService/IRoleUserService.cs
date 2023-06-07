using EasyRuoyi.Application.Services.RoleUserService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleUserService
{
	/// <summary>
	/// 用户角色服务
	/// </summary>
	public interface IRoleUserService
	{
		/// <summary>
		/// 查询用户角色id列表
		/// </summary>
		/// <param name="userId">用户id</param>
		/// <returns></returns>
		Task<IList<Guid>> GetUserRoles(Guid userId);

		/// <summary>
		/// 保存用户角色
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Save(RoleUserSaveInput input);
	}
}
