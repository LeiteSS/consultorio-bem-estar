using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pim.api.Business.DAL;
using pim.api.Business.Entities;
using pim.api.Business.Repository;
using pim.api.Configurations;
using pim.api.Filters;
using pim.api.Models;
using pim.api.Models.Consulta;
using pim.api.Models.Medico;
using pim.api.Models.Paciente;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Controllers
{
    [Route("api/v1/medicos")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly ILogger<MedicosController> _logger;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMedicosDao _medicosDao;
        private readonly IConsultasDao _consultaDao;
        private readonly IAuthenticationServiceCustom _authenticationService;


        public MedicosController(ILogger<MedicosController> logger,
                                   IMedicoRepository medicoRepository,
                                   IMedicosDao medicosDao,
                                   IConsultasDao consultaDao,
                                   IAuthenticationServiceCustom authenticationService)
        {
            _logger = logger;
            _medicoRepository = medicoRepository;
            _consultaDao = consultaDao;
            _medicosDao = medicosDao;
            _authenticationService = authenticationService;
        }


        /// <summary>
        /// Este serviço permite autenticar um medico cadastrado e ativo.
        /// </summary>
        /// <param name="loginMedicoViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginMedicoViewModelOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public async Task<IActionResult> Logar(LoginMedicoViewModelInput loginViewModelInput)
        {
            try
            {
                //var usuario = await _medicoRepository.ObterMedicoAsync(loginViewModelInput.Crm);
                var usuario = await _medicosDao.ObterMedico(loginViewModelInput.Crm);

                if (usuario == null)
                {
                    return BadRequest("Houve um erro ao tentar acessar.");
                }



                var medicoViewModelOutput = new MedicoViewModelOutput()
                {
                    Id = usuario.Id,
                    Crm = loginViewModelInput.Crm,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    DtNascimento = usuario.DtNascimento,
                    TelefoneCelular = usuario.TelefoneCelular,
                    TelefoneFixo = usuario.TelefoneFixo
                };

                var token = _authenticationService.MedicoToken(medicoViewModelOutput);

                return Ok(new LoginMedicoViewModelOutput
                {
                    Token = token,
                    Medico = medicoViewModelOutput
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite cadastrar um medico não existente.
        /// </summary>
        /// <param name="loginViewModelInput">View model do registro de login</param>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(RegistroMedicoViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public async Task<IActionResult> Registrar(RegistroMedicoViewModelInput loginViewModelInput)
        {
            try
            {
                //var medico = await _medicoRepository.ObterMedicoAsync(loginViewModelInput.Crm);
                var medico = await _medicosDao.ObterMedico(loginViewModelInput.Crm);

                if (medico != null)
                {
                    return BadRequest("Usuário já cadastrado");
                }

                medico = new Medico
                {
                    Nome = loginViewModelInput.Nome,
                    Sobrenome = loginViewModelInput.Sobrenome,
                    DtNascimento = loginViewModelInput.DtNascimento,
                    Crm = loginViewModelInput.Crm,
                    Senha = loginViewModelInput.Senha,
                    Email = loginViewModelInput.Email,
                    TelefoneCelular = loginViewModelInput.TelefoneCelular,
                    TelefoneFixo = loginViewModelInput.TelefoneFixo,
                    Especialidade = loginViewModelInput.Especialidade
                };

                //_medicoRepository.Adicionar(medico);
                //_medicoRepository.Commit();
                _medicosDao.Adicionar(medico);

                return Created("", loginViewModelInput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite remarcar uma consulta para o medico autenticado.
        /// </summary>
        /// <returns>Retorna status 201 e dados da consulta do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao agendar uma consulta", Type = typeof(ConsultaViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPut]
        [Route("/remarcar/{id}")]
        [Authorize]
        public async Task<IActionResult> PutRemacarConsulta(int id, ConsultaViewModelInput consultaViewModelInput)
        {
            try
            {
                Consulta consulta = new Consulta
                {
                    DtHora = consultaViewModelInput.DtHora,
                    Descricao = consultaViewModelInput.Descricao,
                    Anexo = consultaViewModelInput.Anexo,
                    Status = Status.Remarcado.ToString(),
                    TransacaoID = Guid.NewGuid()
                };

                //_consultaRepository.Remarcar(id, consulta);
                //_consultaRepository.Commit();
                _medicosDao.Remarcar(id, consulta);

                var consultaViewModelOutput = new ConsultaViewModelOutput
                {
                    DtHora = consulta.DtHora,
                    Descricao = consulta.Descricao,
                    Anexo = consulta.Anexo,
                    Status = consulta.Status,
                    TransacaoID = consulta.TransacaoID
                };

                return Ok(consultaViewModelOutput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite finalizar uma consulta para o medico autenticado.
        /// </summary>
        /// <returns>Retorna status 201 e dados da consulta do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao agendar uma consulta", Type = typeof(ConsultaViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPut]
        [Route("/finalizar/{id}")]
        [Authorize]
        public async Task<IActionResult> PutFinalizarConsulta(int id, ConsultaViewModelInput consultaViewModelInput)
        {
            try
            {
                Consulta consulta = new Consulta
                {
                    DtHora = consultaViewModelInput.DtHora,
                    Descricao = consultaViewModelInput.Descricao,
                    Anexo = consultaViewModelInput.Anexo,
                    Status = Status.Finalizado.ToString(),
                    TransacaoID = Guid.NewGuid()
                };

                //_consultaRepository.Finalizar(id, consulta);
                //_consultaRepository.Commit();
                _medicosDao.Finalizar(id, consulta);


                var consultaViewModelOutput = new ConsultaViewModelOutput
                {
                    DtHora = consulta.DtHora,
                    Descricao = consulta.Descricao,
                    Anexo = consulta.Anexo,
                    Status = consulta.Status,
                    TransacaoID = consulta.TransacaoID
                };

                return Ok(consultaViewModelOutput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite obter todos as consultas agendadas
        /// </summary>
        /// <returns>Retorna status ok e dados da consulta do paciente</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter as consultas", Type = typeof(ConsultaViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("consulta")]
        [Authorize]
        public async Task<IActionResult> GetConsultas()
        {
            try
            {

                var consultas = _medicosDao.ObterConsultas()
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
