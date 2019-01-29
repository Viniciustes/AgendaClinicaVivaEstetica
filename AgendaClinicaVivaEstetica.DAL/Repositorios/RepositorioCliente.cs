using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaClinicaVivaEstetica.DAL.Contextos;
using AgendaClinicaVivaEstetica.Dominio.Entidades;
using AgendaClinicaVivaEstetica.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaClinicaVivaEstetica.DAL.Repositorios
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(DbContexto db) : base(db) { }

        public async Task<IEnumerable<Cliente>> BuscarComEnderecoTodosAsync()
        {
            return await _dbContexto.Clientes.Include(x => x.Endereco).AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> BuscarComEnderecoPorId(Guid id)
        {
            return await _dbContexto.Clientes.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.IdCliente == id);
        }
    }
}
