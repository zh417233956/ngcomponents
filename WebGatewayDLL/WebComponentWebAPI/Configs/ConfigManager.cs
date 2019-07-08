using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentWebAPI.Configs
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
