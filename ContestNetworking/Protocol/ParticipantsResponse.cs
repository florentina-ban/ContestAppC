using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class ParticipantsResponse : IResponse
    {
        public IList<ParticipantDTO> AllParts { get; set; }

        public ParticipantsResponse(IList<ParticipantDTO> allParts)
        {
            AllParts = allParts;
        }
    }
}
