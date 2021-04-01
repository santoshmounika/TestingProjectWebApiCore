using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ntt.Mappers
{
    public sealed class MemberMap : ClassMap<Models.Member>
    {
        public MemberMap()
        {
            Map(x => x.MemberID).Name("MemberID");
            Map(x => x.EnrollmentDate).Name("EnrollmentDate");
            Map(x => x.FirstName).Name("FirstName");
            Map(x => x.LastName).Name("LastName");
            
        }
    }
}
