using Microsoft.Extensions.Configuration;

namespace Sipay.Entity
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sipay.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("DbContext");
            }
        }
    }
}
