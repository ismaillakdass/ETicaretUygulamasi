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
                ConfigurationManager configurationManager = new();//.net 6 ile gelen ConfigurationManager ile appsettings dosyasına ulaşmamızı sağlayan bir yapı
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API")); // appsetting s dizinine konumlanma
                configurationManager.AddJsonFile("appsettings.json");// eklenecek okunacak dosya

                return configurationManager.GetConnectionString("ETicaretAPIConnectionString");
            } 
        }
    }
}
