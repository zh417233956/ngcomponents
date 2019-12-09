using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Models;
using WebComponentUtil.Ioc;

namespace WebComponentStore.Interface
{
    public interface IUserCache : ISingleTonInject
    {
        /// <summary>
        /// 全部用户缓存信息(本地缓存)
        /// </summary>
        /// <returns></returns>
        List<User_Detail> GetUserList();
        /// <summary>
        /// 更新缓存信息
        /// </summary>
        /// <param name="changeUsers"></param>
        /// <returns></returns>
        string SetUserList(List<User_Detail> changeUsers);
        /// <summary>
        /// 获取最后更新时间
        /// </summary>
        /// <returns></returns>
        DateTime GetLastUpdateTime();

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User_Detail GetUser(int userId);

        bool GetIsInit();
        void SetIsInit(bool flag);
    }
}
