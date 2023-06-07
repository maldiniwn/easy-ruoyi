using EasyRuoyi.Application.RemoteServices.FileServerRemoteService;
using EasyRuoyi.Application.Services.UserCenterService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Const;
using EasyRuoyi.Core.DataEncryption.Extensions;
using EasyRuoyi.Core.Extensions;
using EasyRuoyi.Entities.Entities;
using Furion.LinqBuilder;
using Newtonsoft.Json;

namespace EasyRuoyi.Application.Services.UserCenterService
{
	/// <summary>
	/// 用户中心服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "UserCenter", Order = 1)]
	[Route("usercenter")]
	public class UserCenterService : IUserCenterService, IDynamicApiController, ITransient
	{
		private readonly IRepository<Employee> repEmployee;
		private readonly IRepository<UserInfo> repUserInfo;
		private readonly IFileServerRemoteService fileServerRemoteService;

		public UserCenterService(IRepository<Employee> repEmployee
								, IRepository<UserInfo> repUserInfo
								, IFileServerRemoteService fileServerRemoteService)
		{
			this.repEmployee = repEmployee;
			this.repUserInfo = repUserInfo;
			this.fileServerRemoteService = fileServerRemoteService;
		}

		/// <summary>
		/// 修改基本资料
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("editEmp")]
		public async Task EditEmp(EditEmpInput input)
		{
			var employee = await this.repEmployee.FindAsync(input.Id);
			if (null == employee) return;

			employee.Name = input.Name;
			employee.EnumGender = input.EnumGender;
			employee.Tel = input.Tel;
			employee.SID = input.SID;
			employee.BornDate = input.BornDate;

			await this.repEmployee.UpdateAsync(employee);
		}

		/// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("updatePwd")]
		public async Task UpdatePwd(UpdatePwdInput input)
		{
			var userInfo = await this.repUserInfo.FindAsync(input.Id);
			if (userInfo == null) return;

			//判断旧密码是否正确
			string oldPwdSha256 = input.OldPwd.ToSHA256Encryp();
			if (oldPwdSha256 != userInfo.Password)
			{
				throw "旧密码错误！".Ex();
			}

			//判断两次新密码是否一致
			if(input.NewPwd1 != input.NewPwd2) 
			{
				throw "两次新密码不一致！".Ex();
			}

			//更新密码
			userInfo.Password = input.NewPwd1.ToSHA256Encryp();
			await this.repUserInfo.UpdateAsync(userInfo);
		}

		/// <summary>
		/// 查询用户头像url
		/// </summary>
		/// <returns></returns>
		[HttpGet("getHeadUrl")]
		public async Task<string> GetHeadUrl()
		{
			Guid userId = Guid.Parse(App.User.FindFirst(ClaimConst.CLAINM_USERID).Value);
			var employee = await this.repEmployee.DetachedEntities.Query().FirstOrDefaultAsync(a => a.Id == userId);

			string headUrl = "";
			if (null != employee && !string.IsNullOrWhiteSpace(employee.HeadUrl))
			{
				var ids = JsonConvert.DeserializeObject<Guid[]>(employee.HeadUrl);
				string urls = await this.fileServerRemoteService.GetSysFiles(ids);
				var uploadItems = JsonConvert.DeserializeObject<List<UploadItemModel>>(urls);

				if (!uploadItems.IsNullOrEmpty()) headUrl = uploadItems[0].Url;
			}

			return headUrl;
		}

		/// <summary>
		/// 修改头像
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost("updateHeadUrl")]
		public async Task UpdateHeadUrl(UpdateHeadUrlInput input)
		{
			Guid userId = Guid.Parse(App.User.FindFirst(ClaimConst.CLAINM_USERID).Value);
			var employee = await this.repEmployee.FirstOrDefaultAsync(a => a.Id == userId);
			
			if (null == employee) 
			{
				throw "用户不存在！".Ex();
			}

			employee.HeadUrl = input.HeadUrl;
			await this.repEmployee.UpdateAsync(employee);
		}
	}
}
