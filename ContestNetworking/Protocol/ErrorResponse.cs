using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable] public class ErrorResponse : IResponse
    {
        public String Message { get; set; }

        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
