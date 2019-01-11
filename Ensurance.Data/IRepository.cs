using System.Collections.Generic;
using System.Threading.Tasks;
using Ensurance.Model.DTO;

namespace Ensurance.Data
{
    public interface IRepository
    {
        Task<PolicyDTO> AddPolicy(PolicyDTO newPolicy);
        Task DeletePolicy(int id);
        CoverageDTO GetCoverage(int id);
        List<CoverageDTO> GetCoverages();
        List<PolicyDTO> GetPolicies();
        PolicyDTO GetPolicy(int id);
        PolicyCompleteDTO GetPolicyComplete(int id);
        RiskDTO GetRisk(int id);
        List<RiskDTO> GetRisks();
        Task<PolicyDTO> UpdatePolicy(PolicyDTO updatePolicy);
    }
}