using ContestAppC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Repository
{
    interface IRepoParticipant<ID,E> where E:Entity<ID>
    {
        public void Add(E entity);
        public void Delete(ID id);
        public E FindOne(ID id);
        public IList<E> FindAll();
        public void Update(E entity);
        public int GetSize();
    }
}
