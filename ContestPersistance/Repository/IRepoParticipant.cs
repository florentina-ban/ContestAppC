using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestPersistance.Repository
{
    public interface IRepoParticipant:IRepoParticipant<int, Participant>
    {
        Participant FindOneByName(string name);
    }
}
