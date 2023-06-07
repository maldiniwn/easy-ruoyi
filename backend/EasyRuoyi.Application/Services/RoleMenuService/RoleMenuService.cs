using EasyRuoyi.Application.Services.RoleMenuService.Dtos;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Utils;
using EasyRuoyi.Entities.Entities;

namespace EasyRuoyi.Application.Services.RoleMenuService
{
	/// <summary>
	/// 角色菜单服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "RoleMenu", Order = 1)]
	[Route("rolemenu")]
	public class RoleMenuService : IRoleMenuService, IDynamicApiController, ITransient
	{
		private readonly IRepository<RoleMenu> repRoleMenu;

		public RoleMenuService(IRepository<RoleMenu> repRoleMenu)
		{
			this.repRoleMenu = repRoleMenu;
		}

		/// <summary>
		/// 查询角色菜单id列表
		/// </summary>
		/// <param name="roleId">角色id</param>
		/// <returns></returns>
		[HttpGet("getRoleMenus")]
		public async Task<IList<Guid>> GetRoleMenus(Guid roleId)
		{
			var results = await this.repRoleMenu.DetachedEntities.Query().Where(a => a.RoleId == roleId).Select(a => a.MenuId).ToListAsync();
			return results;
		}

		/// <summary>
		/// 保存角色菜单
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("save")]
		[UnitOfWork]
		public async Task Save(RoleMenuSaveInput input)
		{
			//删除现有 角色-菜单 关系
			await this.repRoleMenu.Entities.Where(a => a.RoleId == input.RoleId)
											.ExecuteDeleteAsync();

			//保存新的 角色-菜单 关系
			List<RoleMenu> roleMenus = new();
			foreach (var menuId in input.MenuIds)
			{
				RoleMenu ru = new RoleMenu
				{
					Id = GuidUtil.Create(),
					RoleId = input.RoleId,
					MenuId = menuId
				};
				roleMenus.Add(ru);
			}
			await this.repRoleMenu.InsertAsync(roleMenus);
		}
	}
}
