using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class DeleteRequest : IRequest
    {
        public ParticipantDTO Particip { get; set; }

        public DeleteRequest(ParticipantDTO particip)
        {
            Particip = particip;
        }
    }
}
