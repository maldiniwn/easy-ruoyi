namespace EasyRuoyi.Application.Services.AccountServcie.Dtos
{
	public class CaptchaImageDto
	{
		/// <summary>
		/// 验证码图片Base64
		/// </summary>
		public string CaptchaImageBase64 { get; set; }

		/// <summary>
		/// 验证码Token
		/// </summary>
		public string CaptchaToken { get; set; }
	}
}
