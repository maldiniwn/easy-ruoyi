using EasyRuoyi.Core.Utils;

namespace EasyRuoyi.Application.Services.AccountServcie.Dtos
{
	/// <summary>
	/// 当前登录用户的前端路由 Dto
	/// </summary>
	public class RouterInfoDto : TreeNode<RouterInfoDto>
	{
		///// <summary>
		///// Id
		///// </summary>
		//public Guid Id { get; set; }

		///// <summary>
		///// 父节点
		///// </summary>
		//public Guid? PId { get; set; }

		///// <summary>
		///// 节点名称
		///// </summary>
		//public string Name { get; set; }

		/// <summary>
		/// 菜单全路径
		/// </summary>
		public string FullPath { get; set; }

		/// <summary>
		/// 路径
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// 是否显示
		/// </summary>
		public bool Hidden { get; set; }

		///// <summary>
		///// 重定向
		///// </summary>
		//public string Redirect { get; set; }

		/// <summary>
		/// 组件
		/// </summary>
		public string Component { get; set; }

		///// <summary>
		///// 是否始终显示
		///// </summary>
		//public bool AlwaysShow { get; set; }

		/// <summary>
		/// 路由Meta
		/// </summary>
		public Meta Meta { get; set; } = new Meta();
	}

	/// <summary>
	/// Router Meta
	/// </summary>
	public class Meta
	{
		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 图标
		/// </summary>
		public string Icon { get; set; }

		/// <summary>
		/// 是否缓存（true:会被 keep-alive 缓存）
		/// </summary>
		public bool IsCache { get; set; }

		/// <summary>
		/// tag标签是否固定，不能删除
		/// </summary>
		public bool Affix { get; set; } = false;

		//public string Link { get; set; }
	}
}
