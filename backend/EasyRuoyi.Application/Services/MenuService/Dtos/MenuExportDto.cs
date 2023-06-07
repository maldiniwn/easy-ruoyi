using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.MenuService.Dtos
{
	/// <summary>
	/// 菜单导出模板Dto。
	/// 模板根据需要自行修改。
	/// </summary>
	internal class MenuExportDto<T>
	{
		/// <summary>
		/// 导出模板名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 导出模板数据
		/// </summary>
		public List<T> Menus { get; set; } = new List<T>();
	}
}
