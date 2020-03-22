using ContestAppC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Repository
{
    interface IRepoParticipant:IRepoParticipant<int, Participant>
    {
        public Participant FindOneByName(string name);
    }
}
