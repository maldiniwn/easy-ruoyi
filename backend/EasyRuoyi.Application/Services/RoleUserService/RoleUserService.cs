using EasyRuoyi.Application.Services.RoleUserService.Dtos;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Utils;
using EasyRuoyi.Entities.Entities;

namespace EasyRuoyi.Application.Services.RoleUserService
{
	/// <summary>
	/// 用户角色服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "RoleUser", Order = 1)]
	[Route("roleuser")]
	public class RoleUserService : IRoleUserService, IDynamicApiController, ITransient
	{
		private readonly IRepository<RoleUser> repRoleUser;

		public RoleUserService(IRepository<RoleUser> repRoleUser)
		{
			this.repRoleUser = repRoleUser;
		}

		/// <summary>
		/// 查询用户角色id列表
		/// </summary>
		/// <param name="userId">用户id</param>
		/// <returns></returns>
		[HttpGet("getUserRoles")]
		public async Task<IList<Guid>> GetUserRoles(Guid userId)
		{
			var results = await this.repRoleUser.DetachedEntities.Query().Where(a => a.UserInfoId == userId).Select(a => a.RoleId).ToListAsync();
			return results;
		}

		/// <summary>
		/// 保存用户角色
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("save")]
		[UnitOfWork]
		public async Task Save(RoleUserSaveInput input)
		{
			//删除现有 用户-角色 关系
			await this.repRoleUser.Entities.Where(a => a.UserInfoId == input.UserInfoId)
											.ExecuteDeleteAsync();

			//保存新的 用户-角色 关系
			List<RoleUser> roleUsers = new ();
			foreach (var roleId in input.RoleIds)
			{
				RoleUser ru = new RoleUser
				{
					Id = GuidUtil.Create(),
					UserInfoId = input.UserInfoId,
					RoleId = roleId
				};
				roleUsers.Add(ru);
			}
			await this.repRoleUser.InsertAsync(roleUsers);
		}
	}
}
