using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Models;
using WebComponentWebAPI.Ioc;

namespace WebComponentStore.Interface
{
    public interface IDictStore : ITransentInject
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Dic_Detail GetModel(int id);
    }
}
