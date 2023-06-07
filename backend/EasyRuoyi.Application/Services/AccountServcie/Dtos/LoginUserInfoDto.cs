namespace EasyRuoyi.Application.Services.AccountServcie.Dtos
{
	/// <summary>
	/// 当前登录用户信息、角色编码、菜单权限标识 Dto
	/// </summary>
	public class LoginUserInfoDto
	{
		/// <summary>
		/// 用户Id
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 角色编码
		/// </summary>
		public List<string> RoleCodes { get; set; } = new();

		/// <summary>
		/// 菜单权限标识
		/// </summary>
		public List<string> PermissionCodes { get; set; } = new();
	}
}
