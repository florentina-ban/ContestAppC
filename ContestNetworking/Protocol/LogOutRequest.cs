using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class LogOutRequest : IRequest
    {
        public User user { get; set; }

        public LogOutRequest(User user)
        {
            this.user = user;
        }
    }
}
