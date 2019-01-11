using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Model.DTO
{
    public class PolicyCompleteDTO: PolicyDTO
    {
        public string CoverageName { get; set; }
        public string RiskName { get; set; }
    }
}
