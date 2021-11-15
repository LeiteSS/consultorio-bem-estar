using pim.api.Business.Entities;
using pim.api.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Consulta
{
    public class ConsultaViewModelOutput
    {
        public string Descricao { get; set; }
        public string Anexo { get; set; }
        public string DtHora { get; set; }
        public string Status { get; set; }
        public Guid TransacaoID { get; set; }
        //public PacienteViewModelOutput Paciente { get; set; }
    }
}
