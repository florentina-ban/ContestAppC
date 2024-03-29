﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContestModel.Domain 
{
    [Serializable]
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

      

        public override string ToString()
        {
            return "Age: " + this.Name;
        }
        public bool Apartine(int age)
        {
            return age >= this.StartAge && age <= this.EndAge;

        }

        public override int GetHashCode()
        {
            var hashCode = 1454774529;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + StartAge.GetHashCode();
            hashCode = hashCode * -1521134295 + EndAge.GetHashCode();
            return hashCode;
        }
    }
}
