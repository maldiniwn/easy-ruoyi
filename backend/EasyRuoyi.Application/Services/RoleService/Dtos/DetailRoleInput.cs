using EasyRuoyi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 角色详情 input
	/// </summary>
	public class DetailRoleInput
	{
		/// <summary>
		/// Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }
	}
}
