namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 批量删除用户 input
	/// </summary>
	public class BatchDeleteUserInfoInput
	{
		/// <summary>
		/// Ids
		/// </summary>
		[Required(ErrorMessage = "Ids不能为空")]
		public Guid[] Ids { get; set; }
	}
}
