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


    }
}
