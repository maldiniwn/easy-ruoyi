using EasyRuoyi.Core.Enums;
using Furion.FriendlyException;

namespace EasyRuoyi.Core.Extensions
{
	public static class ErrorCodeExtension
	{
		/// <summary>
		/// 字符串 转换为 AppFriendlyException
		/// 默认code=400
		/// </summary>
		/// <param name="message"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		public static AppFriendlyException Ex(this string message, EnumHttpStatusCode code = EnumHttpStatusCode.BadRequest)
		{
			var ex = Oops.Oh(message);
			ex.StatusCode = (int)code;
			return ex;
		}
	}
}
