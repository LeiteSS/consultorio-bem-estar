using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paciente.web.Models
{
    public class PacienteOutput
    {
        public string Token { get; set; }
        public DetalhePacienteViewModelOutput Paciente { get; set; }
    }

    public class DetalhePacienteViewModelOutput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DtNascimento { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
    }
}
