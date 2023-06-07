using EasyRuoyi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleMenuService.Dtos
{
	/// <summary>
	/// 保存角色菜单 input
	/// </summary>
	public class RoleMenuSaveInput
	{
		/// <summary>
		/// 角色Id
		/// </summary>
		[GuidRequired(ErrorMessage = "角色Id不能为空")]
		public Guid RoleId { get; set; }

		/// <summary>
		/// 菜单Ids
		/// </summary>
		[Required(ErrorMessage = "菜单Id不能为空")]
		public List<Guid> MenuIds { get; set; }
	}
}
