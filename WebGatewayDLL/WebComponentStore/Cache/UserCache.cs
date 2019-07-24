using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComponentStore.Interface;
using WebComponentStore.Models;

namespace WebComponentStore.Cache
{
    public class UserCache : IUserCache
    {
        private List<User_Detail> _UserList = new List<User_Detail>();
        /// <summary>
        /// 用户数据列表
        /// </summary>
        private List<User_Detail> UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
        /// <summary>
        /// list是否正在作业
        /// </summary>
        private bool IsBusies { get; set; }

        private DateTime LastUpdateTime { get; set; }

        public List<User_Detail> GetUserList()
        {
            return UserList;
        }
        /// <summary>
        /// 更新缓存信息
        /// </summary>
        /// <param name="changeUsers"></param>
        /// <returns></returns>
        public string SetUserList(List<User_Detail> changeUsers)
        {
            if (IsBusies)
            {
                return "正在更新用户信息";
            }

            IsBusies = true;
            try
            {
                lock (UserList)
                {
                    foreach (var item in changeUsers)
                    {
                        var itemIndex = UserList.FindIndex(m => m.UserId == item.UserId);
                        if (itemIndex < 0)
                        {
                            UserList.Add(item);
                        }
                        else
                        {
                            UserList[itemIndex] = item;
                        }
                    }
                    //最后更新时间
                    LastUpdateTime = DateTime.Now;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusies = false;
            }

            return "";
        }

        /// <summary>
        /// 获取最后更新时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastUpdateTime()
        {
            return LastUpdateTime;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User_Detail GetUser(int userId)
        {
            var model = UserList.FirstOrDefault(m => m.UserId == userId);

            return model;
        }
    }
}
