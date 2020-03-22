using ContestAppC.Domain;
using ContestAppC.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Validators
{
    interface IValidator<ID, E> where E : Entity<ID>
    {
        public void validate(E entity);

    }
}
