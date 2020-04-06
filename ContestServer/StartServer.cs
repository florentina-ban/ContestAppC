using ContestNetworking.ServerTypes;
using ContestPersistance.Repository;
using ContestPersistance.Validators;
using ContestServer.Server;


namespace ContestServer
{
    class StartServer
    {
        static void Main(string[] args)
        {
            RepoAgeCategory repoAgeCategory = new RepoAgeCategory();
            RepoCompetitions repoCompentition = new RepoCompetitions(repoAgeCategory);
            RepoUsers repoUsers = new RepoUsers();

            ValidatorParticipant validatorParticipant = new ValidatorParticipant();
            RepoParticipants repoParticipants = new RepoParticipants(validatorParticipant);
            validatorParticipant.Repo = repoParticipants;

            ValidatorSignUp validatorSign = new ValidatorSignUp();
            RepoSignUp repoSignUp = new RepoSignUp(repoParticipants, repoCompentition, validatorSign);
            validatorSign.Repo = repoSignUp;

            repoParticipants.MyRepoSignUp = repoSignUp;


            ServiceImpl service = new ServiceImpl(repoAgeCategory, repoCompentition, repoParticipants, repoSignUp,repoUsers);

            MyConcurentServer server = new MyConcurentServer(55555, "127.0.0.1", service);
            server.Start();
            System.Console.WriteLine("Server stared");
            System.Console.ReadLine();
        }
    }
}
