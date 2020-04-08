using ContestModel.Domain;
using System;

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
