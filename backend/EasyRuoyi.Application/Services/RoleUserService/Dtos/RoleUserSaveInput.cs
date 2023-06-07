using EasyRuoyi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleUserService.Dtos
{
	/// <summary>
	/// 保存用户角色 input
	/// </summary>
	public class RoleUserSaveInput
	{
		/// <summary>
		/// 用户Id
		/// </summary>
		[GuidRequired(ErrorMessage = "用户Id不能为空")]
		public Guid UserInfoId { get; set; }

		/// <summary>
		/// 角色Ids
		/// </summary>
		[Required(ErrorMessage = "角色Id不能为空")]
		public List<Guid> RoleIds { get; set; }
	}
}
