using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ntt.Models;
using Ntt.Services;

namespace Ntt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        MemberService memberservice = new MemberService();

        ClaimService claimservice = new ClaimService();

        [HttpGet]
        [RouteAttribute("GetClaimDetailsByMember/{requestedDate}")]
        public IEnumerable<MemberClaimsModel> GetClaimDetailsByMember(string requestedDate)
        {
            try
            {
                List<Models.Member> memberList = new List<Models.Member>();
                List<Models.Claim> claimList = new List<Models.Claim>();


                memberList = GetMemberList();
                claimList = GetClaimsList();

                var memberClaimList = (from m in memberList
                                       select new MemberClaimsModel
                                       {
                                           MemberID = m.MemberID,
                                           FirstName = m.FirstName,
                                           LastName = m.LastName,
                                           ClaimList = (from c in claimList
                                                        where c.MemberID == m.MemberID && c.ClaimDate == requestedDate
                                                        select new Claim()
                                                        {
                                                            ClaimAmount = c.ClaimAmount,
                                                            ClaimDate = c.ClaimDate
                                                        }  ).ToList()
                                       }).ToList();

                return memberClaimList;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Member> GetMemberList()
        {
            return memberservice.ReadMemberCSVFile("C:/Users/medad/source/repos/Ntt/Ntt/ExcelFiles/Member.csv");
        }
        private List<Claim> GetClaimsList()
        {
            return claimservice.ReadClaimCSVFile("C:/Users/medad/source/repos/Ntt/Ntt/ExcelFiles/Claim.csv");
        }

    }
}
