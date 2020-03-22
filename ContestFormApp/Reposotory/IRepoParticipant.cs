using ContestAppC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Repository
{
    public interface IRepoParticipant:IRepoParticipant<int, Participant>
    {
        Participant FindOneByName(string name);
    }
}
