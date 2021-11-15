using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.Entities
{
    public class Usuario : Telefone
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string DtNascimento { get; set; }
        public string Senha { get; set; }
    }
}
