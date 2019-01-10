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
        IEnsuranceContext context = new EnsuranceDBEntities();

        public Repository(IEnsuranceContext context)
        {
            this.context = context;
        }

        public List<PolicyDTO> GetPolicies()
        {
            List<PolicyDTO> policies = new List<PolicyDTO>();
            using (context = new EnsuranceDBEntities())
            {
                context.Policies.AsNoTracking()
                    .Select(p => new PolicyDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description
                    }).ToList();
            }

            return policies;
        }

        public PolicyDTO GetPolicy(int id)
        {
            PolicyDTO policy = new PolicyDTO();
            //using (context = new EnsuranceDBEntities())
            //{
                context.Policies.AsNoTracking()
                    .Where(p => p.Id == id)
                    .Select(p => new PolicyDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description
                    }).FirstOrDefault();
            context.Dispose();
            //}

            return policy;
        }
    }
}
