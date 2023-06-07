using EasyRuoyi.Core.Attributes;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 用户详情 input
	/// </summary>
	public class DetailUserInfoInput
	{
		/// <summary>
		/// Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }
	}
}
