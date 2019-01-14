using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Model.DTO
{
    public class PolicyBasicInfoDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class PolicyDTO: PolicyBasicInfoDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int CoverageType { get; set; }
        [Required]
        public int CoverageTime { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int RiskType { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal CoveragePercentage { get; set; }

    }
}
