using EasyRuoyi.Core.DataEncryption;
using EasyRuoyi.Entities.Entities;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EasyRuoyi.Entities.SeedData
{
	public class UserInfoSeedData : IEntitySeedData<UserInfo>
	{
		public IEnumerable<UserInfo> HasData(DbContext dbContext, Type dbContextLocator)
		{
			Guid userId = Guid.Parse(App.Configuration["SeedData:UserInfo:Id"]);
			string userName = App.Configuration["SeedData:UserInfo:UserName"];
			string name = App.Configuration["SeedData:UserInfo:Name"];
			DateTimeOffset time = DateTimeOffset.Parse("2023-1-1");
			return new[]
			{
				new UserInfo{ Id=userId, UserName=userName, Password=SHA256Encryption.Encrypt("123456"), EmployeeId = userId, IsEnable=true, CreatedUserId=userId, CreatedUserName=name, CreatedTime=time, UpdatedUserId=userId,UpdatedUserName=name,UpdatedTime=time, IsDeleted = false}
			};
		}
	}
}
