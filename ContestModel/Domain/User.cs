using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestModel.Domain
{
    [Serializable] public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public override string ToString()
        {
            return "UserName: " + Name;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Name == user.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
