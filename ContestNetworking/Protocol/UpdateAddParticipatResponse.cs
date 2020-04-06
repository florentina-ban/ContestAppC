using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class UpdateAddParticipatResponse : IUpdateResponse
    {
        public ParticipantDTO participantDTO { get; set; }

        public UpdateAddParticipatResponse(ParticipantDTO participantDTO)
        {
            this.participantDTO = participantDTO;
        }
    }
}
