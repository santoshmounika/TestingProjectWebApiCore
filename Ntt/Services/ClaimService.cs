using CsvHelper;
using Ntt.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ntt.Services
{
    public class ClaimService
    {
        public List<Models.Claim> ReadClaimCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<ClaimMap>();
                    var records = csv.GetRecords<Models.Claim>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
