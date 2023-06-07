using EasyRuoyi.Application.Services.UserCenterService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.UserCenterService
{
	/// <summary>
	/// 用户中心服务
	/// </summary>
	public interface IUserCenterService
	{
		/// <summary>
		/// 修改基本资料
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task EditEmp(EditEmpInput input);

		/// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task UpdatePwd(UpdatePwdInput input);

		/// <summary>
		/// 查询用户头像url
		/// </summary>
		/// <returns></returns>
		Task<string> GetHeadUrl();

		/// <summary>
		/// 修改头像
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task UpdateHeadUrl(UpdateHeadUrlInput input);
	}
}
