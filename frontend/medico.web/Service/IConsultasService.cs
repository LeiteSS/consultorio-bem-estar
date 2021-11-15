using medico.web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medico.web.Service
{
    public interface IConsultasService
    {
        [Post("/api/v1/medicos/finalizar")]
        [Headers("Authorization: Bearer")]
        Task<Consulta> Finalizar(Consulta consulta);

        [Post("/api/v1/medicos/remarcar")]
        [Headers("Authorization: Bearer")]
        Task<Consulta> Remarcar(Consulta consulta);

        [Get("/api/v1/medicos/consultas")]
        [Headers("Authorization: Bearer")]
        Task<IList<Consulta>> Obter();
    }
}
