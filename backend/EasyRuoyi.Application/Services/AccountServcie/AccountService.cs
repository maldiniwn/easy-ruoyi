using EasyRuoyi.Application.Services.AccountServcie.Dtos;
using EasyRuoyi.Core.Const;
using EasyRuoyi.Core.DataEncryption;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Core.Options;
using EasyRuoyi.Core.Utils;
using EasyRuoyi.Entities.Entities;
using EasyRuoyi.Entities.Enums;
using Furion.LinqBuilder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace EasyRuoyi.Application.Services.AccountServcie
{
	/// <summary>
	/// 账户服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "Account", Order = 1)]
	[Route("account")]
	public class AccountService : IAccountService, IDynamicApiController, ITransient
	{
		private readonly IRepository<UserInfo> _repUserInfo;
		private readonly IRepository<Role> _repRole;
		private readonly IRepository<Menu> _repMenu;
		private readonly IRepository<RoleUser> _repRoleUser;
		private readonly IRepository<RoleMenu> _repRoleMenu;
		private readonly IMemoryCache _memoryCache;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AccountService(IRepository<UserInfo> repUserInfo
							, IRepository<Role> repRole
							, IRepository<Menu> repMenu
							, IRepository<RoleUser> repRoleUser
							, IRepository<RoleMenu> repRoleMenu
							, IMemoryCache memoryCache
							, IHttpContextAccessor httpContextAccessor)
		{
			this._repUserInfo = repUserInfo;
			this._repRole = repRole;
			this._repMenu = repMenu;
			this._repRoleUser = repRoleUser;
			this._repRoleMenu = repRoleMenu;
			this._memoryCache = memoryCache;
			this._httpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// 验证码图片
		/// </summary>
		/// <returns></returns>
		[HttpGet("captchaImage")]
		[AllowAnonymous]
		public async Task<CaptchaImageDto> CaptchaImage()
		{
			var (code, bytes) = ValidateCodeUtil.CreateValidateGraphic();
			CaptchaImageDto result = new CaptchaImageDto
			{
				CaptchaImageBase64 = $"data:image/jpg;base64,{Convert.ToBase64String(bytes)}",
				CaptchaToken = Guid.NewGuid().ToString()
			};

			//缓存验证码正确位置集合，20分钟后过期
			var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20));
			this._memoryCache.Set($"{CommonConst.CACHE_KEY_CODE}{result.CaptchaToken}", code, cacheOptions);

			//DistributedCacheEntryOptions cacheOptions = new()
			//{
			//	AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(20)
			//};
			//await this._cache.SetStringAsync($"{CommonConst.CACHE_KEY_CODE}{result.CaptchaToken}", code, cacheOptions);

			Console.WriteLine($"{CommonConst.CACHE_KEY_CODE}{result.CaptchaToken}---{code}");

			await Task.CompletedTask;
			return result;
		}

		/// <summary>
		/// 登录，返回token
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<LoginDto> Login(LoginInput input)
		{
			//判断验证码是否正确
			var code = this._memoryCache.Get($"{CommonConst.CACHE_KEY_CODE}{input.CaptchaToken}");
			//string code = await this._cache.GetStringAsync($"{CommonConst.CACHE_KEY_CODE}{input.CaptchaToken}");
			if (code == null)
			{
				throw "验证码已失效，请重新获取".Ex();
			}
			if (string.Compare(input.Code, (string)code, true) != 0)
			{
				throw "验证码错误".Ex();
			}

			//验证码通过，移除原验证码
			_memoryCache.Remove($"{CommonConst.CACHE_KEY_CODE}{input.CaptchaToken}");
			//await this._cache.RemoveAsync($"{CommonConst.CACHE_KEY_CODE}{input.CaptchaToken}");

			//验证用户名、密码
			UserInfo userinfo = await this._repUserInfo.DetachedEntities.Query()
										.Include(a => a.Employee)
										.FirstOrDefaultAsync(a => a.UserName == input.UserName);

			if (null == userinfo) throw "用户名不存在".Ex();

			string pwd = SHA256Encryption.Encrypt(input.Password);

			if (userinfo.Password != pwd) throw "密码错误".Ex();

			if (userinfo.IsEnable == false) throw "账户已禁用".Ex();

			//判断是否超级管理员角色
			//bool isSuperAdmin = await this._repRoleUser.DetachedEntities.Query().AnyAsync(a => a.UserInfoId == userinfo.Id && a.RoleId == Role.SuperRoleId);

			// 生成Token令牌
			var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>
			{
				{ ClaimConst.CLAINM_USERID, userinfo.Id },
				{ ClaimConst.CLAINM_NAME, userinfo.Employee.Name }
			});

			// 设置Swagger自动登录
			_httpContextAccessor.HttpContext.SigninToSwagger(accessToken);

			// 生成刷新Token令牌
			var refreshToken =
				JWTEncryption.GenerateRefreshToken(accessToken, App.GetOptions<RefreshTokenSettingOptions>().ExpiredTime);

			// 设置刷新Token令牌
			_httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = refreshToken;

			return new LoginDto { Token = accessToken };
		}

		/// <summary>
		/// 获取当前登录用户信息、角色编码、菜单权限标识
		/// </summary>
		/// <returns></returns>
		[HttpGet("getLoginUserInfo")]
		public async Task<LoginUserInfoDto> GetLoginUserInfo()
		{
			Guid userId = Guid.Parse(App.User.FindFirst(ClaimConst.CLAINM_USERID).Value);
			LoginUserInfoDto result = await this._repUserInfo.DetachedEntities.Query().Where(a => a.Id == userId)
																			.Select(a => new LoginUserInfoDto
																			{
																				Id = a.Id,
																				UserName = a.UserName,
																				Name = a.Employee.Name
																			})
																			.FirstOrDefaultAsync();
			if (result == null) throw "用户信息不存在".Ex();

			//超级管理员用户，特殊处理
			if (result.Id == UserInfo.SuperAdminId)
			{
				result.RoleCodes.Add(SystemConst.AdminRoleCode);
				result.PermissionCodes.Add(SystemConst.AdminPermissionCode);
				return result;
			}

			//用户所有角色、菜单
			var query = from ru in this._repRoleUser.DetachedEntities.Query()
						join r in this._repRole.DetachedEntities.Query() on ru.RoleId equals r.Id
						join rm in this._repRoleMenu.DetachedEntities.Query() on r.Id equals rm.RoleId
						join m in this._repMenu.DetachedEntities.Query() on rm.MenuId equals m.Id
						where ru.UserInfoId == result.Id
						select new
						{
							ru.RoleId,
							r.RoleCode,
							rm.MenuId,
							m.PermissionCode
						};
			var list = await query.Distinct().ToListAsync();

			//RoleCode
			result.RoleCodes = list.Select(a => a.RoleCode).Distinct().ToList();
			//如果没有分配角色，则给个默认的
			if (result.RoleCodes.IsNullOrEmpty()) result.RoleCodes.Add("ROLE_DEFAULT");
			//PermissionCodes
			result.PermissionCodes = list.Select(a => a.PermissionCode).Distinct().ToList();

			return result;
		}

		/// <summary>
		/// 获取当前登录用户的前端路由、菜单
		/// </summary>
		/// <returns></returns>
		[HttpGet("getRouterAndMenu")]
		public async Task<RouterAndMenuDto> GetRouterAndMenu()
		{
			Guid userId = Guid.Parse(App.User.FindFirst(ClaimConst.CLAINM_USERID).Value);
			UserInfo userinfo = await this._repUserInfo.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == userId);
			if (userinfo == null) throw "用户信息不存在".Ex();

			List<Menu> menus = null;
			if (userinfo.Id == UserInfo.SuperAdminId)
			{
				//超级管理员用户，直接给全部菜单
				menus = await this._repMenu.DetachedEntities.Query().Where(a => a.EnumMenuType != EnumMenuType.Operation).ToListAsync();
			}
			else
			{
				//非超级管理员用户，根据角色查询菜单
				var query = from ur in this._repRoleUser.DetachedEntities.Query()
							join r in this._repRole.DetachedEntities.Query() on ur.RoleId equals r.Id
							join mr in this._repRoleMenu.DetachedEntities.Query() on r.Id equals mr.RoleId
							join m in this._repMenu.DetachedEntities.Query() on mr.MenuId equals m.Id
							where ur.UserInfoId == userinfo.Id
								&& m.EnumMenuType != EnumMenuType.Operation
							select m;
				menus = await query.Distinct().ToListAsync();
			}

			//将后端菜单转换成前端路由
			List<RouterInfoDto> userRouters = BuildRouter(menus);
			List<MenuInfoDto> userMenus = BuildMenu(menus);

			return new RouterAndMenuDto { Menus = userMenus, Routers = userRouters };
		}

		/// <summary>
		/// 将后端菜单转换成前端路由
		/// </summary>
		/// <param name="menus"></param>
		/// <returns></returns>
		private static List<RouterInfoDto> BuildRouter(List<Menu> menus)
		{
			List<RouterInfoDto> routers = new();

			foreach (Menu m in menus)
			{
				RouterInfoDto r = new();
				r.Id = m.Id;
				r.PId = m.PId;
				r.Name = $"{m.RouterName.First().ToString().ToUpper()}{m.RouterName[1..]}";
				r.FullPath = m.FullPath;
				r.Path = m.Path;
				r.Hidden = !m.IsShow;
				r.Component = m.Component;

				r.Meta = new Meta
				{
					Title = m.Name,
					Icon = m.MenuIcon,
					IsCache = m.IsCache
				};

				routers.Add(r);
			}

			//return routers;
			return TreeBuildUtil<RouterInfoDto>.Build(routers);
		}

		private static List<MenuInfoDto> BuildMenu(List<Menu> menus)
		{
			List<MenuInfoDto> userMenus = menus.Adapt<List<MenuInfoDto>>();

			return TreeBuildUtil<MenuInfoDto>.Build(userMenus);
		}
	}
}
