using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationmanager = new();
                configurationmanager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../BlogMidok/BlogMidok"));
                configurationmanager.AddJsonFile("appsettings.json");

                return configurationmanager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
