using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace paciente.web.Models
{
    public class PacienteInput
    {
        [Required(ErrorMessage = "Use o seu CPF para Logar")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
