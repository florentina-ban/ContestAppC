using System;
using System.Collections.Generic;
using System.Text;

namespace ContestAppC.Domain
{
    public class AgeCategory : Entity<int>
    {
        public string Name { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }

        public AgeCategory(int id, string name, int startAge, int endAge): base(id)
        {
            Name = name;
            StartAge = startAge;
            EndAge = endAge;
        }

        public override bool Equals(object obj)
        {
            return obj is AgeCategory category &&
                   Name == category.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "AgeCategory: " + this.Name;
        }
        public bool Apartine(int age)
        {
            return age >= this.StartAge && age <= this.EndAge;

        }
    }
}
