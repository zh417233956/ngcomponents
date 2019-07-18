using UserSelectionData.Models;
using WebComponentWebAPI.Ioc;
using WebComponentWebAPI.Models;
using WebComponentWebAPI.WCF.Models;

namespace UserSelectionData
{
    public interface IUser_listVistor : ITransentInject
    {
        /// <summary>
        /// 通过id获取一个实体
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        DefaultResult<User_list> GetModelByID(int entityId);
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
