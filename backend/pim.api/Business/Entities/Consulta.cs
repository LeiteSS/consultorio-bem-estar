using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Anexo { get; set; }
        public string DtHora { get; set; }
        public string Status { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public Guid TransacaoID { get; set; }
    }
}
