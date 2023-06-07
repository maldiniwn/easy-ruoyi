using EasyRuoyi.Core.Options;
using Furion;
using Furion.Authorization;
using Furion.DataEncryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileServer.Web.Core
{
	public class JwtHandler : AppAuthorizeHandler
	{
		public override async Task HandleAsync(AuthorizationHandlerContext context)
		{
			var jwtExpiredTime = App.GetOptions<JWTSettingsOptions>().ExpiredTime;
			var refrehExpiredTime = App.GetOptions<RefreshTokenSettingOptions>().ExpiredTime;
			var b = JWTEncryption.AutoRefreshToken(context, context.GetCurrentHttpContext()
							, App.GetOptions<JWTSettingsOptions>().ExpiredTime
							, App.GetOptions<RefreshTokenSettingOptions>().ExpiredTime);
			System.Console.WriteLine($"FileServer jwtExpiredTime:{jwtExpiredTime}  refrehExpiredTime:{refrehExpiredTime}  b:{b}");

			// 自动刷新 token
			if (JWTEncryption.AutoRefreshToken(context, context.GetCurrentHttpContext()
							, App.GetOptions<JWTSettingsOptions>().ExpiredTime
							, App.GetOptions<RefreshTokenSettingOptions>().ExpiredTime))
			{
				await AuthorizeHandleAsync(context);
			}
			else
			{
				context.Fail();    // 授权失败
			}
		}

		public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
		{
			// 这里写您的授权判断逻辑，授权通过返回 true，否则返回 false

			return Task.FromResult(true);
		}
	}
}
