using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace paciente.web.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public string Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtHora { get; set; }
        public string NomePaciente { get; set; }
        public string Anexo { get; set; }
        public Guid TransacaoId { get; set; }
        public string Status { get; set; }

        public List<Consulta> TodasConsultas()
        {
            var consultas = new List<Consulta>
            {
                new Consulta
                {
                    ConsultaId = 1,
                    Descricao = "Doença no brigulino",
                    DtHora =new DateTime(2021,8,20),
                    NomePaciente = "Marcelinho",
                    Anexo = "laudo.pdf",
                    TransacaoId = Guid.NewGuid(),
                    Status = "AGENDADO"
                },
                new Consulta
                {
                    ConsultaId = 2,
                    Descricao = "Doença no brigulino",
                    DtHora = new DateTime(2021,7,30),
                    NomePaciente = "Marcelinho",
                    Anexo = "laudo.pdf",
                    TransacaoId = Guid.NewGuid(),
                    Status = "AGENDADO"
                },
                new Consulta
                {
                    ConsultaId = 3,
                    Descricao = "Doença no brigulino",
                    DtHora = new DateTime(2021,11,15),
                    NomePaciente = "Marcelinho",
                    Anexo = "laudo.pdf",
                    TransacaoId = Guid.NewGuid(),
                    Status = "REMARCADA"
                },
                new Consulta
                {
                    ConsultaId = 4,
                    Descricao = "Doença no brigulino",
                    DtHora = new DateTime(2021,5,15),
                    NomePaciente = "Marcelinho",
                    Anexo = "laudo.pdf",
                    TransacaoId = Guid.NewGuid(),
                    Status = "FINALIZADA"
                },
            };

            return consultas;
        }
    }
}
