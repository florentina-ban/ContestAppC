using System;
using System.Reflection;
using System.Data;

namespace ContestPersistance.Utils
{
    abstract class ConnectionFactory
    {
        private static ConnectionFactory instance;
        
        protected ConnectionFactory()
        {

        }
        public abstract IDbConnection createConnection(); 

        public static ConnectionFactory getInstance()
        {
            if (instance == null)
            {
                Assembly assem = Assembly.GetExecutingAssembly();
                Type[] types = assem.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(ConnectionFactory)))
                        instance = (ConnectionFactory)Activator.CreateInstance(type);
                }
            }
            return instance;
        }
    }
}
