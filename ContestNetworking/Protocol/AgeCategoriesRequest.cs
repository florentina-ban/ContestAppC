using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable] public class AgeCategoriesRequest
    {
        public int Age { get; set; }

        public AgeCategoriesRequest(int age)
        {
            Age = age;
        }
    }
}
