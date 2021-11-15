using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medico.web.Models
{
    public class LoginViewModelOutput
    {
        public string Token { get; set; }
        public DetalheMedicoViewModelOutput Medico { get; set; }
    }

    public class DetalheMedicoViewModelOutput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Crm { get; set; }
        public string Email { get; set; }
        public string DtNascimento { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
    }
}
