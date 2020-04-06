using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ContestPersistance.Utils
{
    public static class ConnectionHelper
    {
        private static IDbConnection instance = null;
        public static IDbConnection getConnection()
        {
            if (instance==null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }
        private static IDbConnection getNewConnection()
        {
            return ConnectionFactory.getInstance().createConnection();
        }

    }
}
