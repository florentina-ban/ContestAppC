using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class AddRequest : IRequest
    {
        public ParticipantDTO participantDTO { get; set; }

        public AddRequest(ParticipantDTO participantDTO)
        {
            this.participantDTO = participantDTO;
        }
    }
}
