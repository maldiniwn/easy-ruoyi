using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 新增角色 input
	/// </summary>
	public class AddRoleInput
	{
		/// <summary>
		/// 名称（唯一）
		/// </summary>
		[Required(ErrorMessage = "名称不能为空")]
		[MaxLength(50)]
		public string Name { get; set; }

		/// <summary>
		/// 角色编号（唯一）
		/// </summary>
		[Required(ErrorMessage = "角色编号不能为空")]
		[MaxLength(50)]
		public string RoleCode { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[Required(ErrorMessage = "是否启用不能为空")]
		[DefaultValue(true)]
		public bool IsEnable { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		public string Description { get; set; }
	}
}
