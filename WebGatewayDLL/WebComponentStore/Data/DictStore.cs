using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Interface;
using WebComponentStore.Models;
using WebComponentWebAPI.Utilitys;

namespace WebComponentStore.Data
{
    public class DictStore : IDictStore
    {
        private const string RedisKey = "_Mango_Mis_SiteCacheHelper_User_Cache_";
        /// <summary>
        /// 获取实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dic_Detail GetModel(int id)
        {
            var model = RedisHelper.Get<Dic_Detail>(RedisKey + id);

            return model;
        }
    }
}
