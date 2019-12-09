using System;
using System.Collections.Generic;
using System.Text;
using WebComponentStore.Models;
using WebComponentUtil.Ioc;

namespace WebComponentStore.Interface
{
    public interface IDictStore : ISingleTonInject
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Dic_Detail GetModel(int id);
    }
}
