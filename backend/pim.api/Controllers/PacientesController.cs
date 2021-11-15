using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pim.api.Business.DAL;
using pim.api.Business.Entities;
using pim.api.Configurations;
using pim.api.Filters;
using pim.api.Models;
using pim.api.Models.Paciente;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Controllers
{
    [Route("api/v1/pacientes")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ILogger<PacientesController> _logger;
        private readonly IPacientesDao _pacientesDao;
        private readonly IAuthenticationServiceCustom _authenticationService;


        public PacientesController(ILogger<PacientesController> logger,
                                   IPacientesDao pacientesDao,
                                   IAuthenticationServiceCustom authenticationService)
        {
            _logger = logger;
            _pacientesDao = pacientesDao;
            _authenticationService = authenticationService;
        }


        /// <summary>
        /// Este serviço permite autenticar um paciente cadastrado e ativo.
        /// </summary>
        /// <param name="loginMedicoViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginPacienteViewModelOutput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public async Task<IActionResult> Logar(LoginPacienteViewModelInput loginViewModelInput)
        {
            try
            {
                //var usuario = await _medicoRepository.ObterMedicoAsync(loginViewModelInput.Crm);
                var usuario = await _pacientesDao.ObterPaciente(loginViewModelInput.Cpf);

                if (usuario == null)
                {
                    return BadRequest("Houve um erro ao tentar acessar.");
                }

                var pacienteViewModelOutput = new PacienteViewModelOutput()
                {
                    Id = usuario.Id,
                    Cpf = loginViewModelInput.Cpf,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    DtNascimento = usuario.DtNascimento,
                    TelefoneCelular = usuario.TelefoneCelular,
                    TelefoneFixo = usuario.TelefoneFixo
                };

                var token = _authenticationService.PacienteToken(pacienteViewModelOutput);

                return Ok(new LoginPacienteViewModelOutput
                {
                    Token = token,
                    Paciente = pacienteViewModelOutput
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite cadastrar um paciente não existente.
        /// </summary>
        /// <param name="loginViewModelInput">View model do registro de login</param>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(RegistroPacienteViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public async Task<IActionResult> Registrar(RegistroPacienteViewModelInput loginViewModelInput)
        {
            try
            {
                //var medico = await _medicoRepository.ObterMedicoAsync(loginViewModelInput.Crm);
                var paciente = await _pacientesDao.ObterPaciente(loginViewModelInput.Cpf);

                if (paciente != null)
                {
                    return BadRequest("Usuário já cadastrado");
                }

                paciente = new Paciente
                {
                    Nome = loginViewModelInput.Nome,
                    Sobrenome = loginViewModelInput.Sobrenome,
                    DtNascimento = loginViewModelInput.DtNascimento,
                    Cpf = loginViewModelInput.Cpf,
                    Senha = loginViewModelInput.Senha,
                    Email = loginViewModelInput.Email,
                    TelefoneCelular = loginViewModelInput.TelefoneCelular,
                    TelefoneFixo = loginViewModelInput.TelefoneFixo,
                };

                _pacientesDao.Adicionar(paciente);

                return Created("", loginViewModelInput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
