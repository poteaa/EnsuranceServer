using Ensurance.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Data
{
    public interface IRepository
    {
        List<PolicyDTO> GetPolicies();
        PolicyDTO GetPolicy(int id);
    }
}
