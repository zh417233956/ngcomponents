using WebComponentWebAPI.Ioc;
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
        DefaultResult<Models.User_list> GetModelByID(int entityId);
    }
}
