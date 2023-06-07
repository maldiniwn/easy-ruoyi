using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 角色导出模板Dto。
	/// 模板根据需要自行修改。
	/// </summary>
	public class UserInfoExportDto<T>
	{
		/// <summary>
		/// 导出模板名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 导出模板数据
		/// </summary>
		public List<T> UserInfos { get; set; } = new List<T>();
	}
}
