using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class ParticipantsRequest : IRequest
    {
        public Competition MyCompetition { get; set; }

        public ParticipantsRequest(Competition myCompetition)
        {
            MyCompetition = myCompetition;
        }
    }
}
