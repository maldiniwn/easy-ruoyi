using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Enums;
using EasyRuoyi.Core.Extensions;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EasyRuoyi.Core.Utils
{
	/// <summary>
	/// 枚举扩展
	/// </summary>
	public static class EnumUtil
	{
		/// <summary>
		/// 所有枚举缓存集合
		/// </summary>
		private static ConcurrentDictionary<string, List<SelectListModel<int>>> _enums = null;

		/// <summary>
		/// 所有枚举列表
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static ConcurrentDictionary<string, List<SelectListModel<int>>> GetAllEnums(Assembly assembly = null)
		{
			if (null == _enums)
			{
				_enums = new ConcurrentDictionary<string, List<SelectListModel<int>>>();
				if (null == assembly) assembly = typeof(EnumUtil).Assembly;
				Type[] allTypes = assembly.GetTypes();
				var allEnumTypes = allTypes.Where(a => a.IsEnum).ToList();

				foreach (var et in allEnumTypes)
				{
					// 获取类型的字段，初始化一个有限长度的字典
					FieldInfo[] enumFields = et.GetFields(BindingFlags.Public | BindingFlags.Static);

					List<SelectListModel<int>> list = new List<SelectListModel<int>>();
					// 遍历字段数组获取key和name
					foreach (FieldInfo enumField in enumFields)
					{
						int intValue = (int)enumField.GetValue(et);
						var desc = enumField.GetDescriptionValue<DescriptionAttribute>();
						SelectListModel<int> m = new SelectListModel<int>
						{
							Value = intValue,
							Label = desc != null && !string.IsNullOrEmpty(desc.Description) ? desc.Description : enumField.Name,
							Extras = enumField.Name
						};
						list.Add(m);
					}
					_enums[et.Name] = list;
				}
			}
			return _enums;
		}

		/// <summary>
		/// 根据枚举类型名称，获取枚举项列表
		/// </summary>
		/// <param name="enumType"></param>
		/// <returns></returns>
		public static List<SelectListModel<int>> GetEnumItems(string enumType)
		{
			if (null == _enums) GetAllEnums();

			if (_enums.ContainsKey(enumType))
			{
				return _enums[enumType];
			}
			else
			{
				return new List<SelectListModel<int>>();
			}
		}

		/// <summary>
		/// 根据枚举类型名称，获取枚举项列表
		/// </summary>
		/// <param name="enumType"></param>
		/// <returns></returns>
		public static List<SelectListModel<int>> GetEnumItems(Type enumType)
		{
			if (!enumType.IsEnum)
				throw Oops.Oh(ErrorCode.D1503);

			if (null == _enums) GetAllEnums();
			
			if (_enums.ContainsKey(enumType.Name))
			{
				return _enums[enumType.Name];
			}
			else
			{
				return new List<SelectListModel<int>>();
			}
		}
	}
}
