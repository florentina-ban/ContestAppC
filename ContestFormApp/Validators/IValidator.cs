using ContestAppC.Domain;
using ContestAppC.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Validators
{
    public interface IValidator<ID, E> where E : Entity<ID>
    {
        void Validate(E entity);

    }
}
