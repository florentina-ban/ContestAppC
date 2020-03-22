using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Domain
{
    public class Participant : Entity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int NoComp { get; set; }

        public Participant(int id, string name, int age) : base(id)
        {
            Name = name;
            Age = age;
            NoComp = 0;
        }

        public override string ToString()
        {
            return "Participant: id=" + base.Id + " name=" + this.Name + " age=" + this.Age;
        }
    }
}
