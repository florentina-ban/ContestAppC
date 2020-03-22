using ContestAppC.Domain;
using ContestAppC.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ContestAppC.Repository
{
    public class RepoAgeCategory : IRepoParticipant<int, AgeCategory>
    {
        public IList<AgeCategory> FindAll()
        {
            IList<AgeCategory> all = new List<AgeCategory>();
            IDbConnection connection = ConnectionHelper.getConnection();
            try
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select id, nume, varstaStart, varstaEnd from categvarsta";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AgeCategory category = new AgeCategory(reader.GetInt32(0), reader.GetString(1)
                                    , reader.GetInt32(2), reader.GetInt32(3));
                            all.Add(category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return all;
        }

        public AgeCategory FindOne(int id)
        {
            AgeCategory category = null;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    string com = "select id, nume, varstaStart, varstaEnd from categVarsta where id=@id;";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = com;
                        IDbDataParameter param = command.CreateParameter();
                        param.Value = id;
                        param.ParameterName = "@id";
                        command.Parameters.Add(param);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                category = new AgeCategory(reader.GetInt32(0), reader.GetString(1)
                                    , reader.GetInt32(2), reader.GetInt32(3));
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return category;
        }

        public int GetSize()
        {
            int count = -1;
            IList<AgeCategory> all = new List<AgeCategory>();
            IDbConnection connection = ConnectionHelper.getConnection();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "select count(*) from categvarsta";
                long x =(Int64) command.ExecuteScalar();
                connection.Close();
                count=(int)x;
            }
            return count;
        }

        public void Update(AgeCategory entity)
        {
            throw new NotImplementedException();
        }
        public void Add(AgeCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
