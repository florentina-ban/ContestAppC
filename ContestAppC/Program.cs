using ContestAppC.Domain;
using ContestAppC.Repository;
using ContestAppC.Utils;
using ContestAppC.Validators;
using System;
using System.Data;

namespace ContestAppC
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RepoAgeCategory repoAgeCategory = new RepoAgeCategory();                       
            RepoCompetitions repoCompentition = new RepoCompetitions(repoAgeCategory);
            
            ValidatorParticipant validatorParticipant = new ValidatorParticipant();
            RepoParticipants repoParticipants = new RepoParticipants(validatorParticipant);
            validatorParticipant.Repo = repoParticipants;
           /* 
            Participant participant = new Participant(100, "Andrei Marius", 9);
            try
            {
                repoParticipants.Add(participant);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */

            ValidatorSignUp validatorSign = new ValidatorSignUp();
            RepoSignUp repoSignUp = new RepoSignUp(repoParticipants, repoCompentition,validatorSign);
            validatorSign.Repo = repoSignUp;
            
             foreach(var el in repoSignUp.getParticipantsForCompetition(2))
                Console.WriteLine(el);

            /*SignUp s = new SignUp(1, 4);
            repoSignUp.Add(s);


            //repoSignUp.Add(s);
            //repoSignUp.Delete(7);
            */

        }
    }
}
