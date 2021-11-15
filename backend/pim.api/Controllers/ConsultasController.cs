using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pim.api.Business.DAL;
using pim.api.Business.Entities;
using pim.api.Business.Repository;
using pim.api.Models.Consulta;
using pim.api.Models.Paciente;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace pim.api.Controllers
{
    [Route("api/v1/consultas")]
    [ApiController]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IConsultasDao _consultaDao;
        private readonly ILogger<MedicosController> _logger;

        public ConsultasController(IConsultaRepository consultaRepository,
                IConsultasDao consultaDao,
                ILogger<MedicosController> logger)
        {
            _consultaDao = consultaDao;
            _consultaRepository = consultaRepository;
            _logger = logger;
        }

        /// <summary>
        /// Este serviço permite agendar uma consulta para o paciente autenticado.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao agendar uma consulta", Type = typeof(ConsultaViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostConsulta(ConsultaViewModelInput consultaViewModelInput)
        {
            
            try
            {
                Consulta consulta = new Consulta
                {
                    DtHora = consultaViewModelInput.DtHora,
                    Descricao = consultaViewModelInput.Descricao,
                    Anexo = consultaViewModelInput.Anexo,
                    Status = Status.Agendado.ToString(),
                    TransacaoID = Guid.NewGuid(),
                };

                var pacienteId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

                consulta.PacienteId = pacienteId;

                _consultaDao.Agendar(consulta);


                var consultaViewModelOutput = new ConsultaViewModelOutput
                {
                    DtHora = consulta.DtHora,
                    Descricao = consulta.Descricao,
                    Anexo = consulta.Anexo,
                    Status = consulta.Status,
                    TransacaoID = consulta.TransacaoID
                };

                return Created("", consultaViewModelOutput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite obter todos as consultas ativas do paciente.
        /// </summary>
        /// <returns>Retorna status ok e dados da consulta do paciente</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter as consultas", Type = typeof(ConsultaViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetConsultasPorPaciente()
        {
            try
            {
                var pacienteId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);


                var consultas = _consultaDao.ObterPorPaciente(pacienteId)
                    .Select(s => new ConsultaViewModelOutput()
                    {
                        DtHora = s.DtHora,
                        Descricao = s.Descricao,
                        Anexo = s.Anexo,
                        Status = s.Status,
                        TransacaoID = s.TransacaoID
                    });

                return Ok(consultas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
