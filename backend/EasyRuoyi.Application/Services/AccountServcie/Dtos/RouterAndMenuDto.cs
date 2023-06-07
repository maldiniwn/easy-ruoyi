using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.AccountServcie.Dtos
{
	/// <summary>
	/// 返回前端路由、菜单
	/// </summary>
	public class RouterAndMenuDto
	{
		/// <summary>
		/// 菜单
		/// </summary>
		public List<MenuInfoDto> Menus { get; set; }

		/// <summary>
		/// 路由
		/// </summary>
		public List<RouterInfoDto> Routers { get; set; }
	}
}
