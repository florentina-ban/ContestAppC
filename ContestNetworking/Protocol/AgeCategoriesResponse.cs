using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    public class AgeCategoriesResponse : IResponse
    {
        public IList<AgeCategory> AllCategs { get; set; }

        public AgeCategoriesResponse(IList<AgeCategory> allCategs)
        {
            this.AllCategs = allCategs;
        }
    }
}
