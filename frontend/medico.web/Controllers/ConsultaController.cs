using medico.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medico.web.Controllers
{
    [Route("Medicos")]
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
        public IActionResult Finalizar()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Remarcar()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult EfetuarFinalizacao()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Iniciar()
        {
            return View();
        }
    }
}
