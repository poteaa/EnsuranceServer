﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Model.DTO
{
    public class PolicyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverageType { get; set; }
        public DateTime StartDate { get; set; }
        public int CoverageTime { get; set; }
        public float Cost { get; set; }
        public int RiskType { get; set; }
        public decimal CoveragePercentage { get; set; }

    }
}