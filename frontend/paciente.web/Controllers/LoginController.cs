using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using paciente.web.Models;
using paciente.web.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace paciente.web.Controllers
{
    [Route("Pacientes")]
    public class LoginController : Controller
    {

        [Route("Login")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("[action]")]
        public IActionResult EfetuarLogoff()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction($"{nameof(Index)}");
        }
    }
}
