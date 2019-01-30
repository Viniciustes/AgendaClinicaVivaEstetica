using AgendaClinicaVivaEstetica.Dominio.Entidades;
using AgendaClinicaVivaEstetica.Dominio.Enumeradores;
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

        public IEnumerable<Cliente> Clientes { get; set; }

        [Display(Name =" Tipo de serviço")]
        public EnumTipoServico EnumTipoServico { get; set; }
    }
}
