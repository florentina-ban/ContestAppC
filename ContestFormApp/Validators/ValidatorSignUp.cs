using ContestAppC.Domain;
using ContestAppC.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Validators
{
    public class ValidatorSignUp : IValidator<int, SignUp>
    {
        public IRepoSignUp Repo { get; set; }

        public void Validate(SignUp entity)
        {
            int nr = Repo.NoSignUpsForParticipant(entity.Participant.Id);
            if (nr >= 2)
                throw new Exception("Participant has already 2 signUps");
        }
    }
}
