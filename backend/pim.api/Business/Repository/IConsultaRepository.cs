using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.Repository
{
    public interface IConsultaRepository
    {
        void Agendar(Consulta consulta);

        void Commit();

        void Remarcar(int id, Consulta consulta);

        void Finalizar(int id, Consulta consulta);

        IList<Consulta> ObterPorPaciente(int medicoId);
    }
}
