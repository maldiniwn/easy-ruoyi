using EasyRuoyi.Core.BusinessModel;

namespace EasyRuoyi.Application.RemoteServices.FileServerRemoteService
{
	/// <summary>
	/// 调用文件服务
	/// </summary>
	public interface IFileServerRemoteService
	{
		/// <summary>
		/// 查询文件列表
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		Task<string> GetSysFiles(Guid[] ids);
	}
}
