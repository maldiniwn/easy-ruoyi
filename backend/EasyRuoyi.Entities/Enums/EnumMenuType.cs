using System.ComponentModel;

namespace EasyRuoyi.Entities.Enums
{
	/// <summary>
	/// 菜单类型
	/// </summary>
	public enum EnumMenuType
	{
		/// <summary>
		/// 目录
		/// </summary>
		[Description("目录")]
		Directory,
		/// <summary>
		/// 菜单
		/// </summary>
		[Description("菜单")]
		Menu,
		/// <summary>
		/// 操作
		/// </summary>
		[Description("操作")]
		Operation
	}
}
