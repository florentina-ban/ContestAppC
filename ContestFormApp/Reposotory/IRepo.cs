using ContestAppC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Repository
{
    public interface IRepoParticipant<ID,E> where E:Entity<ID>
    {
        void Add(E entity);
        void Delete(ID id);
        E FindOne(ID id);
        IList<E> FindAll();
        void Update(E entity);
        int GetSize();
    }
}
