using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.DAL
{
    public interface IMedicosDao
    {
        void Adicionar(Medico medico);

        Task<Medico> ObterMedico(string crm);

        void Remarcar(int id, Consulta consulta);

        void Finalizar(int id, Consulta consulta);

        IList<Consulta> ObterConsultas();
    }
}
