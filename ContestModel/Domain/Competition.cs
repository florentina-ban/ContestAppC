using System;
using System.Collections.Generic;
using System.Text;

namespace ContestModel.Domain
{
    [Serializable]
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

        public override bool Equals(object obj)
        {
            return obj is Competition competition &&
                   Name == competition.Name &&
                   EqualityComparer<AgeCategory>.Default.Equals(Category, competition.Category);
        }

        public override int GetHashCode()
        {
            var hashCode = -808104057;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<AgeCategory>.Default.GetHashCode(Category);
            return hashCode;
        }
    }
}
