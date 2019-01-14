using Ensurance.Model;
using Ensurance.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Data
{
    public class Repository : IRepository
    {
        EnsuranceDBEntities context = new EnsuranceDBEntities();

        public Repository()
        {
        }

        //public Repository(IEnsuranceContext context)
        //{
        //    this.context = context;
        //}

        #region Authentication

        public AuthenticatedUser AuthenticateUser(Authentication login)
        {
            AuthenticatedUser user = null;
            using (var context = new EnsuranceDBEntities())
            {
                user = context.Users.AsNoTracking()
                    .Where(u => u.UserName == login.UserName && u.Password == login.Password)
                    .Select(u => new AuthenticatedUser
                    {
                        Id = u.Id,
                        Name = u.Name,
                        LastName = u.LastName,
                        Username = u.UserName,
                        Token = ""
                    }).FirstOrDefault<AuthenticatedUser>();
            }
            return user;
        }

        #endregion Authentication

        #region Policies

        public List<PolicyDTO> GetPolicies()
        {
            List<PolicyDTO> policies = new List<PolicyDTO>();
            using (var context = new EnsuranceDBEntities())
            {
                policies = context.Policies.AsNoTracking()
                    .Select(p => new PolicyDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CoverageType = p.CoverageType,
                        CoveragePercentage = p.CoveragePercentage,
                        CoverageTime = p.CoverageTime,
                        Cost = p.Cost,
                        RiskType = p.RiskType
                    }).ToList();
            }

            return policies;
        }

        public List<PolicyBasicInfoDTO> GetPoliciesBasicInfo()
        {
            List<PolicyBasicInfoDTO> policiesMin = new List<PolicyBasicInfoDTO>();
            using (var context = new EnsuranceDBEntities())
            {
                policiesMin = context.Policies.AsNoTracking()
                    .Select(p => new PolicyBasicInfoDTO
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
            }

            return policiesMin;
        }

        public PolicyDTO GetPolicy(int id)
        {
            PolicyDTO policy;
            using (var context = new EnsuranceDBEntities())
            {
                policy = context.Policies.AsNoTracking()
                    .Where(p => p.Id == id)
                    .Select(p => new PolicyDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CoverageType = p.CoverageType,
                        CoveragePercentage = p.CoveragePercentage,
                        CoverageTime = p.CoverageTime,
                        Cost = p.Cost,
                        RiskType = p.RiskType
                    }).FirstOrDefault();
            }

            return policy;
        }

        public PolicyCompleteDTO GetPolicyComplete(int id)
        {
            PolicyCompleteDTO policy;
            using (var context = new EnsuranceDBEntities())
            {
                policy = context.Policies.AsNoTracking()
                    .Where(p => p.Id == id)
                    .Select(p => new PolicyCompleteDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CoverageType = p.CoverageType,
                        CoveragePercentage = p.CoveragePercentage,
                        CoverageTime = p.CoverageTime,
                        Cost = p.Cost,
                        RiskType = p.RiskType,
                        CoverageName = p.Coverage.Name,
                        RiskName = p.Risk.Name
                    }).FirstOrDefault();
            }

            return policy;
        }

        public async Task<PolicyDTO> AddPolicy(PolicyDTO newPolicy)
        {
            Policy policy = null;
            using (var context = new EnsuranceDBEntities())
            {
                var existingPolicy = context.Policies
                    .Any(p => (p.Name == newPolicy.Name.Trim()));

                if (!existingPolicy)
                {
                    policy = new Policy
                    {
                        Name = newPolicy.Name,
                        Description = newPolicy.Description,
                        CoverageType = newPolicy.CoverageType,
                        CoveragePercentage = newPolicy.CoveragePercentage,
                        CoverageTime = newPolicy.CoverageTime,
                        Cost = newPolicy.Cost,
                        RiskType = newPolicy.RiskType
                    };
                    context.Policies.Add(policy);
                    await context.SaveChangesAsync();
                    newPolicy.Id = policy.Id;
                }
                else
                {
                    throw new Exception("A policy with the same name already exists.");
                }
            }

            return newPolicy;
        }

        public async Task<PolicyDTO> UpdatePolicy(PolicyDTO updatePolicy)
        {
            var context1 = new EnsuranceDBEntities();
            using (var context = new EnsuranceDBEntities())
            {
                var policy = context.Policies
                        .Where(p => (p.Id == updatePolicy.Id))
                        .FirstOrDefault();
                
                if (policy != null)
                {
                    policy.Name = updatePolicy.Name;
                    policy.Description = updatePolicy.Description;
                    policy.CoverageType = updatePolicy.CoverageType;
                    policy.CoveragePercentage = updatePolicy.CoveragePercentage;
                    policy.CoverageTime = updatePolicy.CoverageTime;
                    policy.Cost = updatePolicy.Cost;
                    policy.RiskType = updatePolicy.RiskType;
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The policy does not exist.");
                }
            }

            return updatePolicy;
        }

        public async Task DeletePolicy(int id)
        {
            using (var context = new EnsuranceDBEntities())
            {
                var policy = new Policy { Id = id };
                context.Policies.Attach(policy);
                context.Policies.Remove(policy);
                await context.SaveChangesAsync();
            }
        }

        #endregion Policies

        #region Coverages

        public List<CoverageDTO> GetCoverages()
        {
            List<CoverageDTO> coverages = new List<CoverageDTO>();
            using (var context = new EnsuranceDBEntities())
            {
                coverages = context.Coverages.AsNoTracking()
                    .Select(c => new CoverageDTO
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
            }

            return coverages;
        }

        public CoverageDTO GetCoverage(int id)
        {
            CoverageDTO coverage;
            using (var context = new EnsuranceDBEntities())
            {
                coverage = context.Coverages.AsNoTracking()
                    .Where(c => c.Id == id)
                    .Select(c => new CoverageDTO
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).FirstOrDefault();
            }

            return coverage;
        }

        #endregion Coverages

        #region Risks

        public List<RiskDTO> GetRisks()
        {
            List<RiskDTO> risks = new List<RiskDTO>();
            using (var context = new EnsuranceDBEntities())
            {
                risks = context.Risks.AsNoTracking()
                    .Select(r => new RiskDTO
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();
            }

            return risks;
        }

        public RiskDTO GetRisk(int id)
        {
            RiskDTO risk;
            using (var context = new EnsuranceDBEntities())
            {
                risk = context.Policies.AsNoTracking()
                    .Where(r => r.Id == id)
                    .Select(r => new RiskDTO
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).FirstOrDefault();
            }

            return risk;
        }

        #endregion Risks

        #region Clients

        public List<ClientBasicInfoDTO> GetClientsBasicInfo()
        {
            List<ClientBasicInfoDTO> clientsMin = new List<ClientBasicInfoDTO>();
            using (var context = new EnsuranceDBEntities())
            {
                clientsMin = context.Clients.AsNoTracking()
                    .Select(c => new ClientBasicInfoDTO
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    }).ToList<ClientBasicInfoDTO>();
            }

            return clientsMin;
        }
        public ClientBasicInfoDTO GetClientBasicInfo(int id)
        {
            ClientBasicInfoDTO clientBasicInfo = null;
            using (var context = new EnsuranceDBEntities())
            {
                clientBasicInfo = context.Clients.AsNoTracking()
                    .Where(c => c.Id == id)
                    .Select(c => new ClientBasicInfoDTO
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    }).FirstOrDefault<ClientBasicInfoDTO>();
            }

            return clientBasicInfo;
        }
        
        public ClientDTO GetClient(int id)
        {
            ClientDTO client;
            using (var context = new EnsuranceDBEntities())
            {
                //var client = context.Clients.AsNoTracking()
                //                    .Where(c => c.Id == id).FirstOrDefault();

                client = context.Clients.AsNoTracking()
                            .Select(c => new ClientDTO
                            {
                                Id = c.Id,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                PolicyIds = c.ClientPolicies.Select(p => p.PolicyId).ToList<int>()
                            }).FirstOrDefault();
            }

            return client;
        }

        #endregion Clients

        #region ClientPolicies

        public List<ClientPolicyDTO> GetClientPolicyByClientId(int clientId)
        {
            List<ClientPolicyDTO> clientPolicyDTO = new List<ClientPolicyDTO>();
            using (var context = new EnsuranceDBEntities())
            {
                clientPolicyDTO = context.ClientPolicies
                    .Where(cp => cp.ClientId == clientId)
                    .Select(cp => new ClientPolicyDTO
                    {
                        Id = cp.Id,
                        ClientId = clientId,
                        PolicyId = cp.PolicyId,
                        PolicyName = cp.Policy.Name,
                        StartDate = cp.StartDate
                    }).ToList<ClientPolicyDTO>();
            }

            return clientPolicyDTO;
        }

        public async Task<ClientPolicyDTO> AddClientPolicy(ClientPolicyDTO newClientPolicy)
        {
            ClientPolicy clientPolicy = null;
            List<int> idsToRemove = new List<int>();
            using (var context = new EnsuranceDBEntities())
            {
                var existingClientPolicy = context.ClientPolicies
                    .Any(cp => cp.ClientId == newClientPolicy.ClientId
                                && cp.PolicyId == newClientPolicy.PolicyId);

                if (!existingClientPolicy)
                {
                    clientPolicy = new ClientPolicy
                    {
                        ClientId = newClientPolicy.ClientId,
                        PolicyId = newClientPolicy.PolicyId,
                        StartDate = DateTime.Now
                    };
                    context.ClientPolicies.Add(clientPolicy);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The client already has this policy.");
                }

            }

            return newClientPolicy;
        }

        public async Task DeleteClientPolicy(int id)
        {
            using (var context = new EnsuranceDBEntities())
            {
                var tmpClientPolicy = new ClientPolicy
                {
                    Id = id
                };
                context.ClientPolicies.Attach(tmpClientPolicy);
                context.ClientPolicies.Remove(tmpClientPolicy);
                await context.SaveChangesAsync();
            }

        }

        #endregion ClientPolicies

    }
}
