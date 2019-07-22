using WebComponentWebAPI.Ioc;
using WebComponentWebAPI.Models;

namespace UserSelectionData
{
    public interface IUser_listService : ITransentInject
    {
        /// <summary>
        /// 通过指定的ids获取实例列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ClientResult GetModelByIds(string ids);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        ClientResult GetUserList();
    }
}
