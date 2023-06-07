using EasyRuoyi.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 角色分页查询 input
	/// </summary>
	public class PageRoleInput : PageInputBase
	{
		/// <summary>
		/// 角色名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 角色编号
		/// </summary>
		public string RoleCode { get; set; }
	}
}
