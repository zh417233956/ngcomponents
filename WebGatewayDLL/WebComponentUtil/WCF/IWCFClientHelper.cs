using WebComponentUtil.Ioc;

namespace WebComponentUtil.WCF
{
    /// <summary>
    /// WCF连接帮助类接口
    /// </summary>
    public interface IWCFClientHelper : ISingleTonInject
    {
        /// <summary>
        /// 获取WCF连接接口通道
        /// </summary>
        /// <typeparam name="MT"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        ISecondBaseInterface<MT> GetInterfaces<MT>(string url);

        /// <summary>
        /// 解密返回的实体
        /// </summary>
        /// <param name="result"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        object Decrypt_v2019(object result, string key, string iv);

        /// <summary>
        /// 具体解密字符串
        /// </summary>
        /// <param name="encryptedValue"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        string DESDecryptString(string encryptedValue, string key, string iv);
    }
}
