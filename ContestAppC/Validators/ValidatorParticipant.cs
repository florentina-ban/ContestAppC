using ContestAppC.Domain;
using ContestAppC.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Validators
{
    class ValidatorParticipant : IValidator<int, Participant>
    {
        public IRepoParticipant Repo { get; set; }

        public ValidatorParticipant()
        {
        }

        public void validate(Participant entity)
        {
            if (Repo.FindOneByName(entity.Name) != null)
                throw new Exception("Name already exists in database");
        }
    }
}
