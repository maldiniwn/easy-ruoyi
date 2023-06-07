using EasyRuoyi.Core.Utils;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 用户分页查询 input
	/// </summary>
	public class PageUserInfoInput : PageInputBase
	{
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		public bool? IsEnable { get; set; }
	}
}
