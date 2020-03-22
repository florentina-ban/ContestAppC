using ContestAppC.Domain;
using ContestAppC.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Validators
{
    public class ValidatorParticipant : IValidator<int, Participant>
    {
        public IRepoParticipant Repo { get; set; }

        public ValidatorParticipant()
        {
        }

        public void Validate(Participant entity)
        {
            if (Repo.FindOneByName(entity.Name) != null)
                throw new Exception("Name already exists in database");
        }
    }
}
