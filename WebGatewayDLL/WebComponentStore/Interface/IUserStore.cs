using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Models;
using WebComponentWebAPI.Ioc;

namespace WebComponentStore.Interface
{
    public interface IUserStore : ITransentInject
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User_Detail GetUser(int userId);
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="model"></param>
        void SetUser(User_Detail model);
    }
}
