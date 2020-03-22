using ContestAppC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Repository
{
    interface IRepoSignUp : IRepoParticipant<int,SignUp>
    {
        public IList<Competition> getCompetitionsForParticipant(int IdPart);
        public IList<Participant> getParticipantsForCompetition(int IdComp);
        public int NoSignUpsForParticipant(int idPart);
    }
}
