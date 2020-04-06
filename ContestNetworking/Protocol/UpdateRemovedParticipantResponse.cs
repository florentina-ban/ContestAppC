using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class UpdateRemovedParticipantResponse : IUpdateResponse
    {
        public ParticipantDTO participant { get; set; }

        public UpdateRemovedParticipantResponse(ParticipantDTO participant)
        {
            this.participant = participant;
        }
    }
}
