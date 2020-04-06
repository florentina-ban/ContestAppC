using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestModel.Domain
{
    [Serializable]
    public class ParticipantDTO : Entity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int NoComp { get; set; }
        public Competition Competition1 { get; set; }
        public Competition Competition2 { get; set; }

        public ParticipantDTO(Participant p, IList<Competition> comps) : base(p.Id)
        {
            this.Name = p.Name;
            this.Age = p.Age;
            this.NoComp = comps.Count>=2 ? 2 : comps.Count;
            if (NoComp >= 1)
                this.Competition1 = comps[0];
            else
                this.Competition1 = null;
            if (NoComp == 2)
                this.Competition2 = comps[1];
            else
                this.Competition2 = null;
        }
        public ParticipantDTO(Participant p, Competition c1,Competition c2 ) : base(p.Id)
        {
            this.Name = p.Name;
            this.Age = p.Age;
            this.NoComp = p.NoComp;
            if (c1==null && c2!=null)
            {
                Competition aux = c1;
                c1 = c2;
                c2 = aux;
            }   
            this.Competition1 = c1;
            this.Competition2 = c2;
           
        }
        public Participant GetParticipantFromDTO()
        {
            Participant p = new Participant(Id, Name, Age);
            p.NoComp = this.NoComp;
            return p;
        }

        public override bool Equals(object obj)
        {
            if (obj is ParticipantDTO)
                return this.Id == ((ParticipantDTO)obj).Id;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
