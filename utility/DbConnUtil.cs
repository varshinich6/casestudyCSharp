using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace casestudy.utility
{
    internal static class DbConnUtil
    {
        private static IConfiguration _iconfiguration;
        //constructor
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
