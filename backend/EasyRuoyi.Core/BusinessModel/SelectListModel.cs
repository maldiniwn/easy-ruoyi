using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.BusinessModel
{
    /// <summary>
    /// 下拉框实体类
    /// </summary>
    public class SelectListModel<T>
    {
        /// <summary>
        /// 值
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        public string Label { get; set; }

		/// <summary>
		/// 额外的信息（如：枚举的名称）
		/// </summary>
		public string Extras { get; set; }
    }
}
