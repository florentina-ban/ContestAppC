using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace ContestPersistance.Utils
{
    class MySqlConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            System.Console.WriteLine(ConfigurationManager.ConnectionStrings);
            ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings["mySql"] ;
            if(connectionSettings!=null)
                return new MySqlConnection(connectionSettings.ConnectionString);
            return null;
        }
    }
}
