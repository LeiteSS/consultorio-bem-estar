using Microsoft.EntityFrameworkCore;
using pim.api.Business.Entities;
using pim.api.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Infraestruture.Data.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultasDbContext _context;

        public MedicoRepository(ConsultasDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Medico medico)
        {
            _context.Medico.Add(medico);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<Medico> ObterMedicoAsync(string crm)
        {
            return await _context.Medico.FirstOrDefaultAsync(u => u.Crm == crm);
        }
    }
}
