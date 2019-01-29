using AgendaClinicaVivaEstetica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaClinicaVivaEstetica.Dominio.Interfaces
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Task<Cliente> BuscarComEnderecoPorId(Guid id);

        Task<IEnumerable<Cliente>> BuscarComEnderecoTodosAsync();
    }
}
