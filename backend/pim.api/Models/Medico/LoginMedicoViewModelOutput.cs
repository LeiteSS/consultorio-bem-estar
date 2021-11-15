using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Medico
{
    public class LoginMedicoViewModelOutput
    {
        public string Token { get; set; }
        public MedicoViewModelOutput Medico { get; set; }
    }
}
