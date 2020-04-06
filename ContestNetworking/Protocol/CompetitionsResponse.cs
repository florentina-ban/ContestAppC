using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    class CompetitionsResponse : IResponse
    {
        public IList<Competition> allComps { get; set; }

        public CompetitionsResponse(IList<Competition> allComps)
        {
            this.allComps = allComps;
        }
    }
}
