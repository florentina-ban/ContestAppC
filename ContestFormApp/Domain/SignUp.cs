using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Domain
{
    public class SignUp : Entity<int>
    {
        public Participant Participant { get; set; }
        public Competition Competition { get; set; }

        public SignUp(int id,Participant part, Competition comp):base(id)
        {
            Participant = part;
            Competition = comp;
        }
        public SignUp(Participant part, Competition comp) : base(-1)
        {
            Participant = part;
            Competition = comp;
        }

        public override string ToString()
        {
            return "Participant: " + Participant + " Competition: " + Competition;
        }
    }
}
