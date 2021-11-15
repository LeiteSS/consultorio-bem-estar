using Microsoft.AspNetCore.Mvc;
using paciente.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paciente.web.Controllers
{
    [Route("Pacientes")]
    public class ConsultaController : Controller
    {
        private readonly List<Consulta> todosAsConsultas; 

        public ConsultaController()
        {
            todosAsConsultas = new Consulta().TodasConsultas().ToList();
        }

        [Route("Consultas")]
        public IActionResult Index()
        {
            ViewBag.Consultas = "Consultas";
            return View(todosAsConsultas);
        }

        [Route("[action]")]
        public IActionResult Agendar()
        {
            return View();
        }

    }
}
