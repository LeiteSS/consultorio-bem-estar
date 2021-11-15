using Microsoft.EntityFrameworkCore;
using pim.api.Business.Entities;
using pim.api.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Infraestruture.Data.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ConsultasDbContext _context;

        public ConsultaRepository(ConsultasDbContext context)
        {
            _context = context;
        }

        public void Agendar(Consulta consulta)
        {
            _context.Consulta.Add(consulta);
        }

        public void Remarcar(int id, Consulta consulta)
        {
            var consultaFounded = _context.Consulta.FirstOrDefault(item => item.Id == id);

            if (consultaFounded != null)
            {
                consultaFounded.Descricao = consulta.Descricao;
                consultaFounded.Anexo = consulta.Anexo;
                consultaFounded.DtHora = consulta.DtHora;
                consultaFounded.Status = consulta.Status;
                consultaFounded.TransacaoID = consulta.TransacaoID;

                _context.SaveChanges();
            }
        }

        public void Finalizar(int id, Consulta consulta)
        {
            var consultaFounded = _context.Consulta.FirstOrDefault(item => item.Id == id);

            if (consultaFounded != null)
            {
                consultaFounded.Descricao = consulta.Descricao;
                consultaFounded.Anexo = consulta.Anexo;
                consultaFounded.DtHora = consulta.DtHora;
                consultaFounded.Status = consulta.Status;
                consultaFounded.TransacaoID = consulta.TransacaoID;

                _context.SaveChanges();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Consulta> ObterPorPaciente(int pacienteId)
        {
            return _context.Consulta.Include(i => i.Paciente).Where(w => w.PacienteId == pacienteId).ToList();
        }

        
    }
}
