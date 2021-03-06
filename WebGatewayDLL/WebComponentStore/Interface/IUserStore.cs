﻿using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Models;
using WebComponentUtil.Ioc;

namespace WebComponentStore.Interface
{
    public interface IUserStore : ISingleTonInject
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
        /// <summary>
        /// 获取所有用户的keys
        /// </summary>
        /// <returns></returns>
        List<int> GetUserKeys();
    }
}
