using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.Entities
{
    public class Paciente : Usuario
    {
        public string Cpf { get; set;  }
    }
}
