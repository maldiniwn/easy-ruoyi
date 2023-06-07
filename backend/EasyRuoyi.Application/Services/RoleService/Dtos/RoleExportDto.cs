using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 角色导出模板Dto。
	/// 模板根据需要自行修改。
	/// </summary>
	public class RoleExportDto<T>
	{
		/// <summary>
		/// 导出模板名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 导出模板数据
		/// </summary>
		public List<T> Roles { get; set; } = new List<T>();
	}
}
