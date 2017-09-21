using System;
using System.Configuration;
using System.IO;

namespace Wrestler.Utils
{
    public static class ConfigSettingsReader
    {
        public static string BrowserName => ConfigurationManager.AppSettings["Browser"];
        public static string AppUrl => ConfigurationManager.AppSettings["ApplicationUrl"];
        public static string PathToFilesForUpload => AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FilesForUploadDir"];
        
        public static double DefaultTimeOut()
        {
            double result = 0;
            double.TryParse(ConfigurationManager.AppSettings["DefaultTimeOut"], out result);
            return result;
        }
        
    }
}
