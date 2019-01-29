using AgendaClinicaVivaEstetica.Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaClinicaVivaEstetica.Apresentacao.Models
{
    public class MarcacaoViewModel
    {
        public MarcacaoViewModel()
        {
            Marcacao = new Marcacao();
            Clientes = new List<Cliente>();
        }

        public Marcacao Marcacao { get; set; }

        [Required(ErrorMessage = ("Cliente deve ser selecionado."))]
        public IEnumerable<Cliente> Clientes { get; set; }
    }
}
