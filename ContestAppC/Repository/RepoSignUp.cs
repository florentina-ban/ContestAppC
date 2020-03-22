using ContestAppC.Domain;
using ContestAppC.Utils;
using ContestAppC.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ContestAppC.Repository
{
    class RepoSignUp : IRepoSignUp
    {
        class SignUpDTO : Entity<int>
        {
            public int ParicipantId { get; set; }
            public int CompetitionId { get; set; }

            public SignUpDTO(int id, int paricipantId, int competitionId) : base(id)
            {
                ParicipantId = paricipantId;
                CompetitionId = competitionId;
            }
        }

        RepoParticipants RepoParticipants;
        RepoCompetitions RepoCompetitions;
        public IValidator<int,SignUp> Validator { get; set; }

        public RepoSignUp(RepoParticipants repoParticipants, RepoCompetitions repoCompetitions,IValidator<int,SignUp> val)
        {
            RepoParticipants = repoParticipants;
            RepoCompetitions = repoCompetitions;
            Validator = val;
        }

        public void Add(SignUp entity)
        {
            try
            {
                Validator.validate(entity);
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    string str = "insert into partprobe (IdPart, IdProba) values (@idpart, @idprob);";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = str;
                        IDbDataParameter idPart = command.CreateParameter();
                        idPart.ParameterName = "@idpart";
                        idPart.Value = entity.Participant.Id;
                        IDbDataParameter idProba = command.CreateParameter();
                        idProba.ParameterName = "@idprob";
                        idProba.Value = entity.Competition.Id;
                        command.Parameters.Add(idPart);
                        command.Parameters.Add(idProba);
                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
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
                    string str = "delete from partprobe where NrInscriere=@id";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = str;
                        IDbDataParameter idP = command.CreateParameter();
                        idP.ParameterName = "@id";
                        idP.Value = id;
                        command.Parameters.Add(idP);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IList<SignUp> FindAll()
        {
            IList<SignUpDTO> allDtos = new List<SignUpDTO>();
            IList<SignUp> all = new List<SignUp>();
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.IdPart, p.IdProba, p.NrInscriere FROM partprobe p;";
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SignUpDTO s = new SignUpDTO(reader.GetInt32(2), reader.GetInt32(0), reader.GetInt32(1));
                                allDtos.Add(s);
                            }
                        }
                    }
                }
                foreach (var dto in allDtos)
                {
                    all.Add(new SignUp(this.RepoParticipants.FindOne(dto.ParicipantId), this.RepoCompetitions.FindOne(dto.CompetitionId)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return all;
        }

        public SignUp FindOne(int id)
        {
            SignUp signUp = null;
            SignUpDTO signUpDTO = null;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.IdPart, p.IdProba, p.NrInscriere FROM partprobe p where p.NrInscriere=@id";
                        IDataParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "@id";
                        parameter.Value = id;
                        command.Parameters.Add(parameter);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                signUpDTO = new SignUpDTO(reader.GetInt32(2), reader.GetInt32(0), reader.GetInt32(1));
                            }
                        }
                    }
                }
                signUp = new SignUp(this.RepoParticipants.FindOne(signUpDTO.ParicipantId), this.RepoCompetitions.FindOne(signUpDTO.CompetitionId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return signUp;
        }

        public IList<Competition> getCompetitionsForParticipant(int IdPart)
        {
            IList<int> allIds = new List<int>();
            IList<Competition> allComp = new List<Competition>();
            try {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.IdProba FROM partprobe p where IdPart=@idP;";
                        IDbDataParameter id = command.CreateParameter();
                        id.ParameterName = "@idP";
                        id.Value = IdPart;
                        command.Parameters.Add(id);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                allIds.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
                foreach (var id in allIds)
                    allComp.Add(this.RepoCompetitions.FindOne(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return allComp;
        }

        public IList<Participant> getParticipantsForCompetition(int IdComp)
        {
            IList<Participant> allPart = new List<Participant>();
            IList<int> allIds = new List<int>();
            try {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                { 
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.IdPart FROM partprobe p where IdProba=@idP;";
                        IDbDataParameter id = command.CreateParameter();
                        id.ParameterName = "@idP";
                        id.Value = IdComp;
                        command.Parameters.Add(id);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                allIds.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
                foreach (var id in allIds)
                    allPart.Add(this.RepoParticipants.FindOne(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allPart;
        }

        public int GetSize()
        {
            int size = -1;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT count(*) FROM partprobe p;";
                        long nr = (long)command.ExecuteScalar();
                        size = (int)nr;
                    }
                }
            }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            return size;
        }

        public int NoSignUpsForParticipant(int idPart)
        {
            int size = -1;
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT count(*) FROM partprobe p where p.IdPart=@idP;";
                        IDataParameter idP = command.CreateParameter();
                        idP.ParameterName = "@idP";
                        idP.Value = idPart;
                        command.Parameters.Add(idP);
                        long nr = (long)command.ExecuteScalar();
                        size = (int)nr;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return size;
        }

        public void Update(SignUp entity)
        {
            throw new NotImplementedException();
        }
    }
}
