using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Model.DTO
{
    public class ClientPolicyDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
