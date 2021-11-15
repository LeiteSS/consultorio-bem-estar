
using medico.web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medico.web.Services
{
    public interface ILoginService
    {

        [Post("/api/v1/medicos/logar")]
        Task<LoginViewModelOutput> Logar(LoginViewModelInput medico);
    }
}
