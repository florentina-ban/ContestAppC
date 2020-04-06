using ContestModel.Domain;
using ContestPersistance.Utils;
using System;
using System.Collections.Generic;
using System.Data;


namespace ContestPersistance.Repository
{
    public class RepoCompetitions : IRepoParticipant<int, Competition>
    {
        class CompetitionDTO : Entity<int>
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }

            public CompetitionDTO(int id,string name, int categoryID):base(id)
            {
                Name = name;
                CategoryID = categoryID;
            }
        }

        public RepoAgeCategory RepoCategory { get; set; }

        public RepoCompetitions(RepoAgeCategory repoCategory)
        {
            RepoCategory = repoCategory;
        }

        public IList<Competition> FindAll()
        {
            List<CompetitionDTO> allDTOS = new List<CompetitionDTO>();
            List<Competition> all = new List<Competition>();
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.numeProba, p.idProba, p.idCateg FROM probe p; ";
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompetitionDTO competitionDTO = new CompetitionDTO(reader.GetInt32(1), reader.GetString(0), reader.GetInt32(2));
                                allDTOS.Add(competitionDTO);
                            }
                        }

                    }

                }
                foreach (var dto in allDTOS){
                    all.Add(new Competition(dto.Id, dto.Name, RepoCategory.FindOne(dto.CategoryID)));
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return all;
        }

        public Competition FindOne(int id)
        {
            CompetitionDTO competitionDTO = null;
            Competition competition=null;
            using (IDbConnection connection = ConnectionHelper.getConnection())
            {
                try
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.numeProba, p.idProba, p.idCateg FROM probe p where idProba=@idP";
                        IDataParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "@idP";
                        parameter.Value = id;
                        command.Parameters.Add(parameter);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                competitionDTO = new CompetitionDTO(reader.GetInt32(1), reader.GetString(0), reader.GetInt32(2));
                            }
                        }
                    }
                    competition = new Competition(competitionDTO.Id, competitionDTO.Name, RepoCategory.FindOne(competitionDTO.CategoryID));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return competition;
        }

        public int GetSize()
        {
            int count = -1;
            using (IDbConnection connection = ConnectionHelper.getConnection())
            {
                try
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select count(*) from Probe";
                        long x=(Int64)command.ExecuteScalar();
                        count = (int)x;
                            
                        }
                  }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return count;
        }

        public IList<Competition> GetCompetitionForCategory(AgeCategory cat)
        {
            List<CompetitionDTO> allDTOS = new List<CompetitionDTO>();
            List<Competition> all = new List<Competition>();
            try
            {
                using (IDbConnection connection = ConnectionHelper.getConnection())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.numeProba, p.idProba, p.idCateg FROM probe p where p.idCateg=@id; ";
                        IDataParameter id = command.CreateParameter();
                        id.ParameterName = "@id";
                        id.Value = cat.Id;
                        command.Parameters.Add(id);
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompetitionDTO competitionDTO = new CompetitionDTO(reader.GetInt32(1), reader.GetString(0), reader.GetInt32(2));
                                allDTOS.Add(competitionDTO);
                            }
                        }

                    }

                }
                foreach (var dto in allDTOS)
                {
                    all.Add(new Competition(dto.Id, dto.Name, RepoCategory.FindOne(dto.CategoryID)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return all;
        }

        public void Update(Competition entity)
        {
            throw new NotImplementedException();
        }
        public void Add(Competition entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
