using AgendaClinicaVivaEstetica.DAL.Contextos;
using AgendaClinicaVivaEstetica.Dominio.Entidades;
using AgendaClinicaVivaEstetica.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaClinicaVivaEstetica.DAL.Repositorios
{
    public class RepositorioMarcacao : Repositorio<Marcacao>, IRepositorioMarcacao
    {
        public RepositorioMarcacao(DbContexto db) : base(db) { }

        public async Task<IEnumerable<Marcacao>> BuscarComClientesTodosAsync()
        {
            return await BuscarPorCliente().ToListAsync();
        }

        public async Task<Marcacao> BuscarComClientePorIdAsync(Guid id)
        {
            return await BuscarPorCliente().FirstOrDefaultAsync(x => x.IdMarcacao == id);
        }

        private IQueryable<Marcacao> BuscarPorCliente()
        {
            return _dbContexto.Marcacoes.Include(x => x.Cliente).AsNoTracking();
        }
    }
}
