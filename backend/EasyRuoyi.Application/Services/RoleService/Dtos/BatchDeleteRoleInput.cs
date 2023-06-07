using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 批量删除角色 input
	/// </summary>
	public class BatchDeleteRoleInput
	{
		/// <summary>
		/// Ids
		/// </summary>
		[Required(ErrorMessage = "Ids不能为空")]
		public Guid[] Ids { get; set; }
	}
}
