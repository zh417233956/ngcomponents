using System;
using System.Collections.Generic;
using System.Text;
using WebComponentData.Models;
using WebComponentUtil.Ioc;
using WebComponentUtil.WCF.Models;

namespace WebComponentData.Interface
{
    public interface IPub_DictVistor: ISingleTonInject
    {
       /// <summary>
       /// 通过指定ID获取字典列表
       /// </summary>
       /// <param name="classId"></param>
       /// <returns></returns>
        DefaultResult<List<Pub_Dict>> GetListByClassId(int classId);
    }
}
