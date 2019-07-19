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


        /// <summary>
        /// 获取指定分类中的字典
        /// </summary>
        /// <param name="DicClassID"></param>
        /// <param name="DicId"></param>
        /// <returns></returns>
        public List<Dic_Detail> GetDicModel(int DicClassID,int DicId)
        {
            var model = RedisHelper.Get<List<Dic_Detail>>(RedisKey + DicId);

            return model;
        }
    }
}
