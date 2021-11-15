using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Paciente
{
    public class PacienteViewModelOutput
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
