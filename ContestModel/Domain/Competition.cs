using System;
using System.Collections.Generic;
using System.Text;

namespace ContestModel.Domain
{
    public class Competition : Entity<int>
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
            return this.Name; 
        }
    }
}
