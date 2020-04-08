using ContestModel.Domain;
using System;


namespace ContestNetworking.Protocol
{
    [Serializable] 
    public class OkResponse : IResponse
    {
        public ParticipantDTO participant { get; set; }

        public OkResponse(ParticipantDTO participant)
        {
            this.participant = participant;
        }
    }
}
