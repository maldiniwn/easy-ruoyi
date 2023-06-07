using EasyRuoyi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.UserCenterService.Dtos
{
	/// <summary>
	/// 修改密码 input
	/// </summary>
	public class UpdatePwdInput
	{
		/// <summary>
		/// 用户Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }

		/// <summary>
		/// 旧密码
		/// </summary>
		[Required(ErrorMessage = "旧密码不能为空")]
		public string OldPwd { get; set; }

		/// <summary>
		/// 新密码
		/// </summary>
		[Required(ErrorMessage = "新密码不能为空")]
		public string NewPwd1 { get; set; }

		/// <summary>
		/// 确认密码
		/// </summary>
		[Required(ErrorMessage = "确认密码不能为空")]
		public string NewPwd2 { get; set; }
	}
}
