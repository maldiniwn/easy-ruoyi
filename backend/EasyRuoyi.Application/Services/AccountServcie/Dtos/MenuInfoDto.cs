using EasyRuoyi.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.AccountServcie.Dtos
{
	/// <summary>
	/// 当前登录用户的前端菜单信息 Dto
	/// </summary>
	public class MenuInfoDto : TreeNode<MenuInfoDto>
	{
		/// <summary>
		/// 菜单全路径
		/// </summary>
		public string FullPath { get; set; }

		/// <summary>
		/// 路由路径
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// 菜单图标
		/// </summary>
		public string MenuIcon { get; set; }
	}
}
