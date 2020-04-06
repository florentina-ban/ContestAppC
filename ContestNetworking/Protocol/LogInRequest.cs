using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable] public class LogInRequest : IRequest
    {
        public User NewUser { get; set; }

        public LogInRequest(User newUser)
        {
            NewUser = newUser;
        }
    }
}
