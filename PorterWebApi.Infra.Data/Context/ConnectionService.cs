using Microsoft.Extensions.Configuration;

namespace PorterWebApi.Infra.Data.Context
{
    public class ConnectionService
    {
        public static string connectionString = "";
        public static void Set(IConfiguration config)
        {
            connectionString = config.GetConnectionString("PorterWebApi");
        }
    }
}
