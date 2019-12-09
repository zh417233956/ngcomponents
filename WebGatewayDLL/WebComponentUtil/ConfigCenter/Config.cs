namespace WebComponentUtil.ConfigCenter
{
    /// <summary>
    /// CC配置变量
    /// </summary>
    public class Config
    {
        private string companyKey = "zy";
        /// <summary>
        /// 站点所属公司
        /// </summary>
        public string CompanyKey
        {
            get { return companyKey; }
            set { companyKey = value; }
        }

        private string compute = "zhonghai";
        /// <summary>
        /// 站点所在机器名
        /// </summary>
        public string Compute
        {
            get { return compute; }
            set { compute = value; }
        }


        private string domain = "192.168.4.144";
        /// <summary>
        /// 站点所在机器名域名
        /// </summary>
        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        private string localIp = "192.168.4.144";
        /// <summary>
        /// 站点提供的局域网访问IP
        /// </summary>
        public string LocalIp
        {
            get { return localIp; }
            set { localIp = value; }
        }

        private int localPort = 8032;
        /// <summary>
        /// 站点提供的局域网访问端口号
        /// </summary>
        public int LocalPort
        {
            get { return localPort; }
            set { localPort = value; }
        }

        private string projectKey = "ng-userselect";
        /// <summary>
        /// 站点在跑的是哪个项目
        /// </summary>
        public string ProjectKey
        {
            get { return projectKey; }
            set { projectKey = value; }
        }

        private string accessKeyId = "local";
        /// <summary>
        /// 连接使用的公钥
        /// </summary>
        public string AccessKeyId
        {
            get { return accessKeyId; }
            set { accessKeyId = value; }
        }

        private string accessSecret = "ECdmF0qhIhPjcb5DLnqyGVqHFsbQK5Y8";

        public string AccessSecret
        {
            get { return accessSecret; }
            set { accessSecret = value; }
        }

        private string apiUrl = "http://configcenter2018.517api.cn";

        public string ApiUrl
        {
            get { return apiUrl; }
            set { apiUrl = value; }
        }


        private string singleKey;

        /// <summary>
        /// CC获取配置的通信签名key
        /// </summary>
        public string SingleKey
        {
            get
            {
                return singleKey;
            }
            set
            {
                singleKey = value;
            }
        }

        private string wcfSecretkey;

        /// <summary>
        /// wcf解密密钥
        /// </summary>
        public string WCFSecretkey
        {
            get
            {
                return wcfSecretkey;
            }
            set
            {
                wcfSecretkey = value;
            }
        }

        private string wcfSecretiv;
        /// <summary>
        /// wcf解密偏移向量
        /// </summary>
        public string WCFSecretiv
        {
            get
            {
                return wcfSecretiv;
            }
            set
            {
                wcfSecretiv = value;
            }
        }

        private string wcfPasskey;
        /// <summary>
        /// wcfpasskey
        /// </summary>
        public string WCFPasskey
        {
            get
            {                
                return wcfPasskey;
            }
            set
            {
                wcfPasskey = value;
            }
        }

        //private static string wcfHost = "http://apicache200.517.dev:51707";//"http://192.168.4.98:8061";
        private string wcfHost = "http://192.168.3.109:51707";
        /// <summary>
        /// wcfpasskey
        /// </summary>
        public string WCFHost
        {
            get
            {                
                return wcfHost;
            }
            set
            {
                wcfHost = value;
            }
        }
    }
}
