using medico.web.Models;
using medico.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace medico.web.Controllers
{
    [Route("Medicos")]
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
    }
}
