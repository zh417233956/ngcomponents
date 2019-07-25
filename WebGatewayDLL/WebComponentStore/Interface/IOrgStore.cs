using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Models;
using WebComponentWebAPI.Ioc;

namespace WebComponentStore.Interface
{
    public interface IOrgStore : ISingleTonInject
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Org_Detail GetModel(int id);
    }
}
