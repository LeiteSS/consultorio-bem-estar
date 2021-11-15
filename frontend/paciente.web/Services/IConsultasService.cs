using paciente.web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paciente.web.Services
{
    public interface IConsultasService
    {
        [Post("/api/v1/consultas")]
        [Headers("Authorization: Bearer")]
        Task<Consulta> Agendar(Consulta consulta);

        [Get("/api/v1/consultas")]
        [Headers("Authorization: Bearer")]
        Task<IList<Consulta>> Obter();
    }
}
