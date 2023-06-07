namespace EasyRuoyi.Application.Services.AccountServcie.Dtos
{
	public class LoginInput
	{
		/// <summary>
		/// 用户名
		/// </summary>
		[Required(ErrorMessage = "用户名不能为空！")]
		public string UserName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[Required(ErrorMessage = "密码不能为空！")]
		public string Password { get; set; }

		/// <summary>
		/// 验证码
		/// </summary>
		[Required(ErrorMessage = "验证码不能为空！")]
		public string Code { get; set; }

		/// <summary>
		/// 验证码Token
		/// </summary>
		[Required(ErrorMessage = "验证码Token不能为空！")]
		public string CaptchaToken { get; set; }
	}
}
