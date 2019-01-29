using AgendaClinicaVivaEstetica.DAL.Contextos;
using AgendaClinicaVivaEstetica.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaClinicaVivaEstetica.DAL.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly DbContexto _dbContexto;

        public Repositorio(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public async Task<IEnumerable<T>> BuscarTodosAsync()
        {
            return await _dbContexto.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task SalvarAsync(T entidade)
        {
            _dbContexto.Set<T>().Add(entidade);
            await _dbContexto.SaveChangesAsync();
        }

        public async Task<T> BuscarPorIdAsync(Guid id)
        {
            return await _dbContexto.Set<T>().FindAsync(id);
        }

        public async Task Alterar(T entidade)
        {
            _dbContexto.Update<T>(entidade);
            await _dbContexto.SaveChangesAsync();
        }

        public async Task ApagarPorId(Guid id)
        {
            var entidade = await BuscarPorIdAsync(id);
            _dbContexto.Set<T>().Remove(entidade);
            await _dbContexto.SaveChangesAsync();
        }
    }
}
