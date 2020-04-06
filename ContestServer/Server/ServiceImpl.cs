using ContestModel.Domain;
using ContestPersistance.Repository;
using ContestServices.Services;
using System;

namespace ContestServer.Server
{
    class ServiceImpl : IContestService
    {
        public RepoAgeCategory MyRepoAgeCategory { set; get; }
        public RepoCompetitions MyRepoCompetition { get; set; }
        public IRepoParticipant MyRepoParticipant { get; set; }
        public IRepoSignUp MyRepoSignUp { get; set; }
        public RepoUsers MyRepoUsers { get; set; }

        public ServiceImpl(RepoAgeCategory myRepoAgeCategory, RepoCompetitions myRepoCompetition, IRepoParticipant myRepoParticipant, IRepoSignUp myRepoSignUp, RepoUsers repoUsers)
        {
            MyRepoAgeCategory = myRepoAgeCategory;
            MyRepoCompetition = myRepoCompetition;
            MyRepoParticipant = myRepoParticipant;
            MyRepoSignUp = myRepoSignUp;
            MyRepoUsers = repoUsers;
        }

        public void LogIn(User user, IContestObserver observer)
        {
            if (!MyRepoUsers.FindOne(user))
                throw new Exception("Invalid Data");
        }

        public void LogOut(User user, IContestObserver observer)
        {
            throw new NotImplementedException();
        }
    }
}
