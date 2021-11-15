using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.Entities
{
    public class Medico : Usuario
    {
        public string Crm { get; set; }
        public string Especialidade { get; set; }
    }
}
