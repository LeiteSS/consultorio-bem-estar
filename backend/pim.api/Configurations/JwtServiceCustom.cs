using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pim.api.Models.Medico;
using pim.api.Models.Paciente;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace pim.api.Configurations
{
    public class JwtServiceCustom : IAuthenticationServiceCustom
    {
        private readonly IConfiguration _configuration; 

        public JwtServiceCustom(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string MedicoToken(MedicoViewModelOutput medicoViewModelOutput)
        {
            var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, medicoViewModelOutput.Id.ToString()),
                    new Claim(ClaimTypes.Name, medicoViewModelOutput.Crm.ToString()),
                    new Claim(ClaimTypes.Email, medicoViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }

        public string PacienteToken(PacienteViewModelOutput pacienteViewModelOutput)
        {
            var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, pacienteViewModelOutput.Id.ToString()),
                    new Claim(ClaimTypes.Name, pacienteViewModelOutput.Cpf.ToString()),
                    new Claim(ClaimTypes.Email, pacienteViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}
