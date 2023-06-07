using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyRuoyi.Core.Utils
{
	/// <summary>
	/// 构建树形结构
	/// </summary>
	public static class TreeBuildUtil<T> where T : TreeNode<T>
	{
		/// <summary>
		/// 构建Tree
		/// </summary>
		/// <param name="nodes"></param>
		/// <returns></returns>
		public static List<T> Build(List<T> nodes)
		{
			List<T> roots = nodes.Where(a => a.PId == null || a.PId == Guid.Empty).ToList();
			List<T> results = new();
			foreach (T r in roots)
			{
				BuildChildren(nodes, r);
				results.Add(r);
			}
			return results.OrderBy(a => a.Sort).ToList();
		}

		/// <summary>
		/// 构建子节点
		/// </summary>
		/// <param name="nodes"></param>
		/// <param name="parent"></param>
		private static void BuildChildren(List<T> nodes, T parent)
		{
			List<T> children = nodes.Where(a => a.PId == parent.Id).OrderBy(a => a.Sort).ToList();
			if (children.Count > 0)
			{
				parent.Children = children;
				foreach (var c in children)
				{
					BuildChildren(nodes, c);
				}
			}
		}
	}

	/// <summary>
	/// 树节点
	/// </summary>
	public class TreeNode<T>
	{
		/// <summary>
		/// Id
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// 父节点
		/// </summary>
		public Guid? PId { get; set; }

		/// <summary>
		/// 节点名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Sort { get; set; }

		/// <summary>
		/// 子节点
		/// </summary>
		public List<T> Children { get; set; } = new List<T>();
	}
}
