using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaClinicaVivaEstetica.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> BuscarTodosAsync();

        Task SalvarAsync(T entidade);

        Task<T> BuscarPorIdAsync(Guid id);

        Task Alterar(T entidade);

        Task ApagarPorId(Guid id);
    }
}
