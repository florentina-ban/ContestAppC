using ContestModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    [Serializable]
    class CompetitionsRequest : IRequest
    {
        public AgeCategory ageCategory { get; set; }

        public CompetitionsRequest(AgeCategory ageCategory)
        {
            this.ageCategory = ageCategory;
        }
    }
}
