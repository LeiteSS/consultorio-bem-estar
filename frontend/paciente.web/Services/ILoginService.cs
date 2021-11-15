using paciente.web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paciente.web.Services
{
    public interface ILoginService
    {

        [Post("/api/v1/pacientes/logar")]
        Task<PacienteOutput> Logar(PacienteInput paciente);
    }
}
