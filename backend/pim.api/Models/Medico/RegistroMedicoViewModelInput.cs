using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Medico
{
    public class RegistroMedicoViewModelInput
    {
        [Required(ErrorMessage = "O Crm é obrigatório")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome do paciente é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public string DtNascimento { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "O telefone fixo é obrigatório")]
        public string TelefoneFixo { get; set; }

        public string TelefoneCelular { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
