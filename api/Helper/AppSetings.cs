using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTravelTradeApi.Helper
{
    public interface IAppSettings
    {
        string[] AllowedOrigins { get; set; }
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string SmtpEmail { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string[] AllowedOrigins { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpEmail { get; set; }
    }
}