using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Interface;
using WebComponentStore.Models;
using WebComponentUtil.Utilitys;

namespace WebComponentStore.Data
{
    public class UserStore : IUserStore
    {
        private const string RedisKey = "_MangoUserDetailStore_";

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User_Detail GetUser(int userId)
        {
            var model = RedisHelper.Get<User_Detail>(RedisKey + userId);

            return model;
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="model"></param>
        public void SetUser(User_Detail model)
        {
            RedisHelper.Set(RedisKey + model.UserId, model);
        }
        /// <summary>
        /// 获取所有用户的keys
        /// </summary>
        /// <returns></returns>
        public List<int> GetUserKeys()
        {
            var result = RedisHelper.Get<List<int>>(RedisKey + "keys");
            return result;
        }
    }
}
