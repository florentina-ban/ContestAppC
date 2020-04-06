using ContestModel.Domain;
using ContestPersistance.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestPersistance.Repository
{
    public class RepoUsers
    {
        public bool FindOne(User user)
        {
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    string com = "select count(*) from logindata where user=@user and pass=@pass";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = com;
                        IDbDataParameter us = command.CreateParameter();
                        us.Value = user.Name;
                        us.ParameterName = "@user";
                        command.Parameters.Add(us);
                        IDbDataParameter pas = command.CreateParameter();
                        pas.Value = user.Password;
                        pas.ParameterName = "@pass";
                        command.Parameters.Add(pas);
                        Object ob = command.ExecuteScalar();
                        if (((Int64)ob) == 1)
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
