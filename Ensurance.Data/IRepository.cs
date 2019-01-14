using System.Collections.Generic;
using System.Threading.Tasks;
using Ensurance.Model;
using Ensurance.Model.DTO;

namespace Ensurance.Data
{
    public interface IRepository
    {
        Task<ClientPolicyDTO> AddClientPolicy(ClientPolicyDTO newClientPolicy);
        Task<PolicyDTO> AddPolicy(PolicyDTO newPolicy);
        AuthenticatedUser AuthenticateUser(Authentication login);

        Task DeleteClientPolicy(int id);
        Task DeletePolicy(int id);
        ClientDTO GetClient(int id);
        List<ClientPolicyDTO> GetClientPolicyByClientId(int clientId);
        ClientBasicInfoDTO GetClientBasicInfo(int id);
        List<ClientBasicInfoDTO> GetClientsBasicInfo();
        CoverageDTO GetCoverage(int id);
        List<CoverageDTO> GetCoverages();
        List<PolicyDTO> GetPolicies();
        List<PolicyBasicInfoDTO> GetPoliciesBasicInfo();
        PolicyDTO GetPolicy(int id);
        PolicyCompleteDTO GetPolicyComplete(int id);
        RiskDTO GetRisk(int id);
        List<RiskDTO> GetRisks();
        Task<PolicyDTO> UpdatePolicy(PolicyDTO updatePolicy);
    }
}