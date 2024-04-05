using IConfiguration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace Configuration
{
    public class Configuration : IConfiguration.IConfiguration
    {
        private static IConfigurationRoot configurationRoot;
        static Configuration()
        {
            // 这最后的两个拓展方法要安装Configuration.FileExtensions和Configuration.Json才能用
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configurationRoot = builder.Build();
        }

        // 通过这个就可以获取配置文件的值了
        public string Read(string key)
        {
            return configurationRoot[key];
        }
    }
}
