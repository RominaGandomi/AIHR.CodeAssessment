using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Models
{
    public class ConfigManager
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public DataBase DataBase { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class DataBase
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ConnectionString { get; set; }
    }
}
