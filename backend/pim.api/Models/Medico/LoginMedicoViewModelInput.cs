using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Medico
{
    public class LoginMedicoViewModelInput
    {
        [Required(ErrorMessage = "Use o seu CRM para Logar")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
