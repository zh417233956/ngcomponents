using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Models;
using WebComponentWebAPI.Ioc;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentData.Interface
{
    public interface IPub_DicExtendItemVistor: ITransentInject
    {
        /// <summary>
        /// 获取扩展的字典项
        /// </summary>
        /// <param name="extendKey">扩展索引名</param>
        /// <param name="structKey">结构索引StructName</param>
        /// <returns></returns>
        DefaultResult<List<Pub_DicExtendItem>> GetItemWithOutIsdel(string extendKey, string structKey);
    }
}
