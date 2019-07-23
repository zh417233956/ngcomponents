using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebComponentWebAPI.Configs;
using WebComponentWebAPI.Ioc;
using WebComponentWebAPI.Utilitys;

namespace UserSelectionWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // 加载log4net日志配置文件
            ConfigManager.repository = LogManager.CreateRepository("Web_COM_Repository");
            XmlConfigurator.Configure(ConfigManager.repository, new System.IO.FileInfo("Configs/log4net.config"));

            // Redis连接
            string RedisCon = Configuration.GetConnectionString("Store.Redis");
            string RedisMergeKey = Configuration.GetConnectionString("Store.MergeKey");
            RedisHelper.SetCon(RedisCon, RedisMergeKey);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //依赖注入
            services.AutoRegisterService();
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            var serviceProvider = services.BuildServiceProvider();
            #region 用户数据初始化
            serviceProvider.GetService<UserSelectionData.IUser_listService>();
            #endregion 用户数据初始化

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
