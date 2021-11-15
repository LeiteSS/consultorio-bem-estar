using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Paciente
{
    public class LoginPacienteViewModelInput
    {
        [Required(ErrorMessage = "Use o seu CPF para Logar")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
