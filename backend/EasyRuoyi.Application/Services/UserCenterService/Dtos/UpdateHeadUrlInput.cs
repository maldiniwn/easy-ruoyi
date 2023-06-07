using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.UserCenterService.Dtos
{
	/// <summary>
	/// 修改头像 input
	/// </summary>
	public class UpdateHeadUrlInput
	{
		/// <summary>
		/// 头像
		/// </summary>
		[Required(ErrorMessage = "头像不能为空")]
		public string HeadUrl { get; set; }
	}
}
