using log4net.Repository;

namespace WebComponentUtil.Configs
{
    /// <summary>
    /// 配置管理
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// log4net日志仓储
        /// </summary>
        public static ILoggerRepository repository { get; set; }
    }
}
