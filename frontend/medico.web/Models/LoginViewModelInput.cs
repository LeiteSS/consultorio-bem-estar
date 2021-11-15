using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medico.web.Models
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "Use o seu CRM para Logar")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
