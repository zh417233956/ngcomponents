namespace WebComponentWebAPI.ConfigCenter
{
    /// <summary>
    /// CC配置变量
    /// </summary>
    public class Config
    {
        public const string CompanyKey = "zy";
        public const string Compute = "zhonghai";
        public const string Domain = "192.168.4.144";
        public const string LocalIp = "192.168.4.144";
        public const int LocalPort = 8032;
        public const string ProjectKey = "ng-userselect";

        public const string AccessKeyId = "local";
        public const string AccessSecret = "ECdmF0qhIhPjcb5DLnqyGVqHFsbQK5Y8";
        public const string ApiUrl = "http://configcenter2018.517api.cn";

        private static string singleKey;

        /// <summary>
        /// CC获取配置的通信签名key
        /// </summary>
        public static string SingleKey
        {
            get
            {
                if (string.IsNullOrEmpty(singleKey))
                {
                    singleKey = CCHelper.GetSingleKey();
                }
                return singleKey;
            }
        }

        private static string wcfSecretkey;

        /// <summary>
        /// wcf解密密钥
        /// </summary>
        public static string WCFSecretkey
        {
            get
            {
                if (string.IsNullOrEmpty(wcfSecretkey))
                {
                    wcfSecretkey = CCHelper.GetConfig("wcf.config.conn.third.secretkey", SingleKey);
                }
                return wcfSecretkey;
            }
        }

        private static string wcfSecretiv;
        /// <summary>
        /// wcf解密偏移向量
        /// </summary>
        public static string WCFSecretiv
        {
            get
            {
                if (string.IsNullOrEmpty(wcfSecretiv))
                {
                    wcfSecretiv = CCHelper.GetConfig("wcf.config.conn.third.secretiv", SingleKey);
                }
                return wcfSecretiv;
            }
        }

        private static string wcfPasskey;
        /// <summary>
        /// wcfpasskey
        /// </summary>
        public static string WCFPasskey
        {
            get
            {
                if (string.IsNullOrEmpty(wcfPasskey))
                {
                    wcfPasskey = CCHelper.GetConfig("wcf.config.conn.third.passkey", SingleKey);
                }
                return wcfPasskey;
            }
        }

        private static string wcfHost = "http://apicache200.517.dev:51707";//"http://192.168.4.98:8061";
        /// <summary>
        /// wcfpasskey
        /// </summary>
        public static string WCFHost
        {
            get
            {
                if (string.IsNullOrEmpty(wcfHost))
                {
                    //TODO:需要从服务器拉取，暂时使用的固定值
                    wcfHost = CCHelper.GetConfig("wcf.config.conn.third.host", SingleKey);
                }
                return wcfHost;
            }
        }
    }
}
