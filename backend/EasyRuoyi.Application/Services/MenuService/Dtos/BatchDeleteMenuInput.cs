using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.MenuService.Dtos
{
	/// <summary>
	/// 批量删除菜单 input
	/// </summary>
	public class BatchDeleteMenuInput
	{
		/// <summary>
		/// Ids
		/// </summary>
		[Required(ErrorMessage = "Ids不能为空")]
		public Guid[] Ids { get; set; }
	}
}
