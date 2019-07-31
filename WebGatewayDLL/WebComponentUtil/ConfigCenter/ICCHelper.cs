using System;
using System.Collections.Generic;
using System.Text;
using WebComponentUtil.Ioc;

namespace WebComponentUtil.ConfigCenter
{
    public interface ICCHelper: ISingleTonInject
    {
        /// <summary>
        /// 获取配置参数
        /// </summary>
        /// <returns></returns>
        Config GetConfig();

        /// <summary>
        /// 取得配置
        /// </summary>
        /// <param name="configKey"></param>
        /// <param name="singleKey"></param>
        /// <returns></returns>
        string GetConfig(string configKey, string singleKey);
    }
}
