using ContestModel.Domain;
using ContestNetworking.Protocol;
using ContestPersistance.Repository;
using ContestServices.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContestServer.Server
{
    class ServiceImpl : IContestService
    {
        public RepoAgeCategory MyRepoAgeCategory { set; get; }
        public RepoCompetitions MyRepoCompetition { get; set; }
        public IRepoParticipant MyRepoParticipant { get; set; }
        public IRepoSignUp MyRepoSignUp { get; set; }
        public RepoUsers MyRepoUsers { get; set; }
        public IDictionary<string, IContestObserver> allClients;

        public ServiceImpl(RepoAgeCategory myRepoAgeCategory, RepoCompetitions myRepoCompetition, IRepoParticipant myRepoParticipant, IRepoSignUp myRepoSignUp, RepoUsers repoUsers)
        {
            MyRepoAgeCategory = myRepoAgeCategory;
            MyRepoCompetition = myRepoCompetition;
            MyRepoParticipant = myRepoParticipant;
            MyRepoSignUp = myRepoSignUp;
            MyRepoUsers = repoUsers;
            allClients = new Dictionary<string, IContestObserver>();
        }

        public void LogIn(User user, IContestObserver observer)
        {
            if (allClients.ContainsKey(user.Name))
                throw new Exception("User allready logged in");
            allClients[user.Name] = observer;
            if (!MyRepoUsers.FindOne(user))
                throw new Exception("Invalid Data");
        }

        public void LogOut(User user)
        {
            if (allClients.ContainsKey(user.Name))
                allClients.Remove(user.Name);
            else
                throw new Exception("user not logged in");
        }

        public void nofityAllCientsParticipantRemoved(ParticipantDTO participantDTO,IContestObserver obs)
        {
            foreach(var client in allClients.Values)
            {
                if (client != obs)
                    Task.Run(() => client.ParticipantRemoved(participantDTO));
            }
        }
        public void nofityAllCientsParticipantAdded(ParticipantDTO participantDTO, IContestObserver obs)
        {
            foreach (var client in allClients.Values)
            {
                if (client != obs)
                    Task.Run(() => client.ParticipantAdded(participantDTO));
            }
        }

        public IList<AgeCategory> GetAgeCategories()
        {
            return this.MyRepoAgeCategory.FindAll();
        }
        public IList<Competition> GetCompetitions(AgeCategory ageCategory)
        {
            return this.MyRepoCompetition.GetCompetitionForCategory(ageCategory);
        }
        public IList<ParticipantDTO> GetParticipantDTOs(Competition competition)
        {
            IList<ParticipantDTO> allDtos = new List<ParticipantDTO>();
            if (competition != null)
            {
                IList<Participant> allPart = this.MyRepoSignUp.getParticipantsForCompetition(competition.Id);
                ParticipantDTO participantDTO;
                foreach (Participant p in allPart)
                {
                    participantDTO = new ParticipantDTO(p, this.MyRepoSignUp.getCompetitionsForParticipant(p.Id));
                    allDtos.Add(participantDTO);
                }
            }
            else
            {
                IList<Participant> allPart = this.MyRepoParticipant.FindAll();
                ParticipantDTO participantDTO;
                foreach (Participant p in allPart)
                {
                    participantDTO = new ParticipantDTO(p, this.MyRepoSignUp.getCompetitionsForParticipant(p.Id));
                    allDtos.Add(participantDTO);
                }

            }
            return allDtos;
        }
       
        public void DeleteParticipant(ParticipantDTO participantDTO,IContestObserver obs)
        {
            this.MyRepoParticipant.Delete(participantDTO.Id);
            this.nofityAllCientsParticipantRemoved(participantDTO,obs);
        }
        public ParticipantDTO AddParticipant(ParticipantDTO participantDTO,IContestObserver obs)
        {
            this.MyRepoParticipant.Add(participantDTO.GetParticipantFromDTO());
            int idPart = this.MyRepoParticipant.FindOneByName(participantDTO.Name).Id;
            participantDTO.Id = idPart;
            if (participantDTO.NoComp >= 1)
                this.MyRepoSignUp.Add(new SignUp(participantDTO.GetParticipantFromDTO(),participantDTO.Competition1));
            if (participantDTO.NoComp == 2)
                this.MyRepoSignUp.Add(new SignUp(participantDTO.GetParticipantFromDTO(), participantDTO.Competition2));
            this.nofityAllCientsParticipantAdded(new ParticipantDTO(participantDTO.GetParticipantFromDTO(), participantDTO.Competition1, participantDTO.Competition2),obs);
            return participantDTO;
        }
    }
}
