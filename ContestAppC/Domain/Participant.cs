using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Domain
{
    class Participant : Entity<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Participant(int id, string name, int age) : base(id)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return "Participant: id=" + base.Id + " name=" + this.Name + " age=" + this.Age;
        }
    }
}
