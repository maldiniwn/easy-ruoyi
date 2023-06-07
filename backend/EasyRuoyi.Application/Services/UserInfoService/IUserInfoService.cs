using EasyRuoyi.Application.Services.UserInfoService.Dtos;
using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Utils;

namespace EasyRuoyi.Application.Services.UserInfoService
{
	/// <summary>
	/// 用户服务
	/// </summary>
	public interface IUserInfoService
	{
		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<PageResult<UserInfoDto>> Page([FromQuery] PageUserInfoInput input);

		/// <summary>
		/// 详情
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<UserInfoDto> Detail([FromQuery] DetailUserInfoInput input);

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Add(AddUserInfoInput input);

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Edit(UpdateUserInfoInput input);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task Delete(DeleteUserInfoInput input);

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task BatchDelete(BatchDeleteUserInfoInput input);

		/// <summary>
		/// 下载导入模板
		/// </summary>
		/// <returns></returns>
		Task<FileResult> DownloadTemplate();

		/// <summary>
		/// 导入
		/// </summary>
		/// <param name="file">文件</param>
		/// <param name="updateSupport">是否更新重复数据</param>
		/// <returns></returns>
		Task<ResultModel> Import(IFormFile file, bool updateSupport = false);

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<FileResult> Export([FromQuery] PageUserInfoInput input);
	}
}
