using EasyRuoyi.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.MenuService.Dtos
{
	/// <summary>
	/// 菜单分页 input
	/// </summary>
	public class PageMenuInput : PageInputBase
	{
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		public bool? IsEnable { get; set; }
	}
}
