using EasyRuoyi.Application.Services.AccountServcie.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.AccountServcie
{
	/// <summary>
	/// 账户服务
	/// </summary>
	public interface IAccountService
	{
		/// <summary>
		/// 验证码图片
		/// </summary>
		/// <returns></returns>
		Task<CaptchaImageDto> CaptchaImage();

		/// <summary>
		/// 登录，返回token
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<LoginDto> Login(LoginInput input);

		/// <summary>
		/// 获取当前登录用户信息、角色编码、菜单权限标识
		/// </summary>
		/// <returns></returns>
		Task<LoginUserInfoDto> GetLoginUserInfo();

		/// <summary>
		/// 获取当前登录用户的前端路由、菜单
		/// </summary>
		/// <returns></returns>
		Task<RouterAndMenuDto> GetRouterAndMenu();
	}
}
