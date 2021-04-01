using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ntt.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
  

    public class MemberClaimsModel
    {
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Claim> ClaimList { get; set; }
    }
}
