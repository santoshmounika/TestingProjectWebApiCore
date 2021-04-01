using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ntt.Mappers
{
    
    public sealed class ClaimMap : ClassMap<Models.Claim>
    {
        public ClaimMap()
        {
            Map(x => x.MemberID).Name("MemberID");
            Map(x => x.ClaimDate).Name("ClaimDate");
            Map(x => x.ClaimAmount).Name("ClaimAmount");

        }
    }
}
