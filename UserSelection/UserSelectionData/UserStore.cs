using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSelectionData.Models;
using WebComponentWebAPI.Utilitys;

namespace UserSelectionData
{
    public class UserStore : IUserStore
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User_Detail GetUser(int userId)
        {
            var model = RedisHelper.Get<User_Detail>("mango:user:" + userId);

            return model;
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="model"></param>
        public void SetUser(User_Detail model)
        {
            RedisHelper.Set("mango:user:" + model.UserId, model);
        }
    }
}
