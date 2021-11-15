using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.Repository
{
    public interface IMedicoRepository
    {
        void Adicionar(Medico medico);
        void Commit();

        Task<Medico> ObterMedicoAsync(string crm);
    }
}
