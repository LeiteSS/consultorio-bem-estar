using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Paciente
{
    public class LoginPacienteViewModelOutput
    {
        public string Token { get; set; }
        public PacienteViewModelOutput Paciente { get; set; }
    }
}
