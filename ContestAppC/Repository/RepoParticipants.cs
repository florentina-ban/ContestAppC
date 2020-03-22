﻿using ContestAppC.Domain;
using ContestAppC.Utils;
using ContestAppC.Validators;
using System;
using System.Collections.Generic;
using System.Data;


namespace ContestAppC.Repository
{
    class RepoParticipants : IRepoParticipant
    {
        public ValidatorParticipant Validator { get; set; }

        public RepoParticipants(ValidatorParticipant vali)
        {
            this.Validator = vali;
        }

        public void Add(Participant entity)
        {
            try
            {
                Validator.validate(entity);
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "insert into participanti (nume,varsta) values (@nume,@varsta) ;";                       
                        IDataParameter nume = command.CreateParameter();
                        nume.ParameterName = "@nume";
                        nume.Value = entity.Name;
                        IDataParameter varsta = command.CreateParameter();
                        varsta.ParameterName = "@varsta";
                        varsta.Value = entity.Age;
                        command.Parameters.Add(nume);
                        command.Parameters.Add(varsta);
                        int rows = command.ExecuteNonQuery();
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "delete from participanti where id=@id";
                        IDataParameter idP = command.CreateParameter();
                        idP.ParameterName = "@id";
                        idP.Value = id;
                        command.Parameters.Add(idP);
                        int rows = command.ExecuteNonQuery();
                        Console.WriteLine(rows) ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IList<Participant> FindAll()
        {
            IList<Participant> all = new List<Participant>();
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select Id, nume, varsta from participanti;";
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Participant participant = new Participant(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                                all.Add(participant);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return all;
        }

        public Participant FindOne(int id)
        {
            Participant participant= null;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select p.Id, p.nume, p.varsta, pp.IdProba from participanti p  inner join "
                            +"partprobe pp on pp.IdPart=p.Id where id=@id";
                        IDataParameter idP = command.CreateParameter();
                        idP.ParameterName = "@id";
                        idP.Value = id;
                        command.Parameters.Add(idP);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                participant = new Participant(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                            }
                        }
                       
                    }
                }                   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return participant;
        }

        public Participant FindOneByName(string name)
        {
            Participant participant = null;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select Id, nume, varsta from participanti where nume=@nume";
                        IDataParameter numeP = command.CreateParameter();
                        numeP.ParameterName = "@nume";
                        numeP.Value = name;
                        command.Parameters.Add(numeP);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                participant = new Participant(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return participant;
        }

        public int GetSize()
        {
            int count = -1;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select count(*) from participanti";
                        long x = (Int64)command.ExecuteScalar();
                        count = (int)x;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count;
        }

        public void Update(Participant entity)
        {
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select count(*)from participanti where id=@id";
                        IDataParameter idP = command.CreateParameter();
                        idP.ParameterName = "@id";
                        idP.Value =entity.Id;
                        command.Parameters.Add(idP);
                        long count = (long)command.ExecuteScalar();
                        if ((int)count != 1)
                            throw new Exception("Participant not found");
                        command.Parameters.Clear();
                        command.CommandText = "update Participanti set nume=@nume, varsta=@varsta where id=@id;";
                        IDataParameter nume = command.CreateParameter();
                        nume.ParameterName = "@nume";
                        nume.Value = entity.Name;
                        IDataParameter varsta = command.CreateParameter();
                        varsta.ParameterName = "@varsta";
                        varsta.Value = entity.Age;
                        IDataParameter idP1 = command.CreateParameter();
                        idP1.ParameterName = "@id";
                        idP1.Value = entity.Id;
                        command.Parameters.Add(nume);
                        command.Parameters.Add(varsta);
                        command.Parameters.Add(idP);
                        int rows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}