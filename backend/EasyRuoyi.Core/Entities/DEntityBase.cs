using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRuoyi.Core.Entities
{
	/// <summary>
	/// 自定义实体基类
	/// </summary>
	public abstract class DEntityBase : DEntityBase<Guid, MasterDbContextLocator>
	{
		public DEntityBase()
		{ }
	}

	public abstract class DEntityBase<TKey, TDbContextLocator1> : PrivateDEntityBase<TKey>
		where TDbContextLocator1 : class, IDbContextLocator
	{
	}

	public abstract class PrivateDEntityBase<TKey> : IPrivateEntity
	{
		/// <summary>
		/// 主键Id
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Comment("Id")]
		public virtual TKey Id { get; set; }

		/// <summary>
		/// 创建人Id
		/// </summary>
		[Comment("创建人Id")]
		public virtual Guid? CreatedUserId { get; set; }

		/// <summary>
		/// 创建人名称
		/// </summary>
		[Comment("创建人名称")]
		[MaxLength(50)]
		public virtual string CreatedUserName { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[Comment("创建时间")]
		[Required(ErrorMessage = "创建时间不能为空")]
		public virtual DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now;

		/// <summary>
		/// 修改人Id
		/// </summary>
		[Comment("修改人Id")]
		public virtual Guid? UpdatedUserId { get; set; }

		/// <summary>
		/// 修改人名称
		/// </summary>
		[Comment("修改人名称")]
		[MaxLength(50)]
		public virtual string UpdatedUserName { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[Comment("修改时间")]
		[Required(ErrorMessage = "修改时间不能为空")]
		public virtual DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.Now;

		/// <summary>
		/// 软删除
		/// </summary>
		[Comment("软删除标记")]
		[Required(ErrorMessage = "软删除标记不能为空")]
		public virtual bool IsDeleted { get; set; } = false;

		/// <summary>
		/// 软删除时间
		/// </summary>
		[Comment("软删除时间")]
		public virtual DateTimeOffset? DeletedTime { get; set; }
	}
}
