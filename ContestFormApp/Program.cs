using ContestAppC.Repository;
using ContestAppC.Validators;
using ContestFormApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContestFormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RepoAgeCategory repoAgeCategory = new RepoAgeCategory();
            RepoCompetitions repoCompentition = new RepoCompetitions(repoAgeCategory);

            ValidatorParticipant validatorParticipant = new ValidatorParticipant();
            RepoParticipants repoParticipants = new RepoParticipants(validatorParticipant);
            validatorParticipant.Repo = repoParticipants;
           
            ValidatorSignUp validatorSign = new ValidatorSignUp();
            RepoSignUp repoSignUp = new RepoSignUp(repoParticipants, repoCompentition, validatorSign);
            validatorSign.Repo = repoSignUp;

            repoParticipants.MyRepoSignUp = repoSignUp;
            
            MainService service = new MainService(repoAgeCategory, repoCompentition, repoParticipants, repoSignUp);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(service));
        }
    }
}
