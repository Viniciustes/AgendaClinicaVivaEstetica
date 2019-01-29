using AgendaClinicaVivaEstetica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaClinicaVivaEstetica.Dominio.Interfaces
{
    public interface IRepositorioMarcacao : IRepositorio<Marcacao>
    {
        Task<IEnumerable<Marcacao>> BuscarComClientesTodosAsync();

        Task<Marcacao> BuscarComClientePorIdAsync(Guid id);
    }
}
