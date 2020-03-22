using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace ContestAppC.Utils
{
    class MySqlConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            ConnectionStringSettings connectionSettings =ConfigurationManager.ConnectionStrings["mySql"] ;
            if(connectionSettings!=null)
                return new MySqlConnection(connectionSettings.ConnectionString);
            return null;
        }
    }
}
