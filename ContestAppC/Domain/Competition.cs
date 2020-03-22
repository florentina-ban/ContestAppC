using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Domain
{
    class Competition : Entity<int>
    {
        public string Name { get; set; }
        public AgeCategory Category { get; set; }
        

        public Competition(int id,string nume, AgeCategory category):base(id)
        {
            Name = nume;
            Category = category;
        }

        public override string ToString()
        {
            return "Competition: " + this.Name +" category: "+this.Category; 
        }
    }
}
