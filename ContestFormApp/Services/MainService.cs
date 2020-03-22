using ContestAppC.Domain;
using ContestAppC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestFormApp.Services
{
    public class MainService
    {
        public RepoAgeCategory MyRepoAgeCategory { set; get; }
        public RepoCompetitions MyRepoCompetition { get; set; }
        public IRepoParticipant MyRepoParticipant { get; set; }
        public IRepoSignUp MyRepoSignUp { get; set; }

        public MainService(RepoAgeCategory myRepoAgeCategory, RepoCompetitions myRepoCompetition, IRepoParticipant myRepoParticipant, IRepoSignUp myRepoSignUp)
        {
            MyRepoAgeCategory = myRepoAgeCategory;
            MyRepoCompetition = myRepoCompetition;
            MyRepoParticipant = myRepoParticipant;
            MyRepoSignUp = myRepoSignUp;
        }
    
        public IList<AgeCategory> GetAgeCategories()
        {
            return MyRepoAgeCategory.FindAll();
        }

        public IList<Competition> GetCompetitionsForAgeCategory(AgeCategory category)
        {
            return MyRepoCompetition.GetCompetitionForCategory(category);
        }
        public IList<Participant> GetParticipantsForCompetition(Competition competition)
        {
            return MyRepoSignUp.getParticipantsForCompetition(competition.Id);
        }
        public IList<Participant> getAllParticipants()
        {
            return MyRepoParticipant.FindAll();
        }
        public IList<Competition> GetCompetitionsForParticipant(Participant p)
        {
            return MyRepoSignUp.getCompetitionsForParticipant(p.Id);
        }
        public void DeleteParticpant(Participant p)
        {
            MyRepoParticipant.Delete(p.Id);
        }
    }
}
