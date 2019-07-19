using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Interface;
using WebComponentStore.Models;
using WebComponentWebAPI.Utilitys;

namespace WebComponentStore.Data
{
    public class OrgStore : IOrgStore
    {
        private const string RedisKey = "_MangoOrgDetailStore_";
        /// <summary>
        /// 获取实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Org_Detail GetModel(int id)
        {
            var model = RedisHelper.Get<Org_Detail>(RedisKey + id);

            return model;
        }
    }
}
