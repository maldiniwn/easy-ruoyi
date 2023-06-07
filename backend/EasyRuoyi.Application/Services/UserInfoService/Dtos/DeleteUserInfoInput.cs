using EasyRuoyi.Core.Attributes;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 删除用户 input
	/// </summary>
	public class DeleteUserInfoInput
	{
		/// <summary>
		/// Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }
	}
}
