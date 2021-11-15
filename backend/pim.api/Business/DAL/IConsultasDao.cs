using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.DAL
{
    public interface IConsultasDao
    {
        void Agendar(Consulta consulta);

        IList<Consulta> ObterPorPaciente(int pacienteId);

        Task<Paciente> ObterPaciente();
    }
}
