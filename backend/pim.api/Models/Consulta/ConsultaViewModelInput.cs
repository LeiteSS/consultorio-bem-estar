using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Models.Consulta
{
    public class ConsultaViewModelInput
    {
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Anexo é obrigatória")]
        public string Anexo { get; set; }

        [Required(ErrorMessage = "A data e hora é obrigatória")]
        public string DtHora { get; set; }

        /*public string Status { get; set; }

        public Guid TransacaoID { get; set; }*/
    }
}
