using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Business.DAL
{
    public interface IPacientesDao
    {
        void Adicionar(Paciente paciente);

        Task<Paciente> ObterPaciente(string cpf);
    }
}
