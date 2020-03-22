using ContestAppC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Repository
{
    public interface IRepoSignUp : IRepoParticipant<int,SignUp>
    {
        IList<Competition> getCompetitionsForParticipant(int IdPart);
        IList<Participant> getParticipantsForCompetition(int IdComp);
        int NoSignUpsForParticipant(int idPart);
    }
}
