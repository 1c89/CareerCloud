using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    internal class DatabaseConnectionParameters
    {
        public static string ConnectionString { get; }
       
        static DatabaseConnectionParameters() 
        {
            var config = new ConfigurationBuilder();
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            
            config.AddJsonFile(path, false);
            
            var root = config.Build();
            
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;

        }
    }
}
