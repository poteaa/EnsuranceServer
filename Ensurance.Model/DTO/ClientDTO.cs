using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Model.DTO
{
    public class ClientBasicInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ClientDTO: ClientBasicInfoDTO
    {
        public List<int> PolicyIds { get; set; }
    }
}
