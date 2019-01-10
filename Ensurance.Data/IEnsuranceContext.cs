using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Data
{
    public interface IEnsuranceContext: IDisposable
    {
        DbSet<Coverage> Coverages { get; set; }
        DbSet<Policy> Policies { get; set; }
        DbSet<Risk> Risks { get; set; }
    }
}
