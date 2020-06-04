using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CustomORM.Framework
{
    /// <summary>
    /// 固定读取根目录下的appsettings.json
    /// </summary>
    public class ConfigrationManager
    {
        private static string _SqlConnectionString = null;
        public static string SqlConnectionString
        {
            get => _SqlConnectionString;
        }

        static ConfigrationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            _SqlConnectionString = configuration["connectionString"];
        }
    }
}
