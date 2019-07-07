using System;

namespace WebComponentAPIGateway
{
    public class WebComponentHelper
    {
        /// <summary>
        /// 获取API数据
        /// </summary>
        /// <param name="host">请求的主机地址</param>
        /// <param name="path">路径</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public string GetAPIData(string host,string path,string param) {
            string result = "";
            try
            {
                //TODO:进行请求转发，通过微服务API获取真正的组件数据
                result = param;
            }
            catch (Exception)
            {
                //TODO:异常数据通过LTC进行记录
            }
            return result;
        }
    }
}
