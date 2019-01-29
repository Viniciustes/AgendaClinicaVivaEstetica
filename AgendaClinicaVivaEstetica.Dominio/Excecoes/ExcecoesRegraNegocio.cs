using System;

namespace AgendaClinicaVivaEstetica.Dominio.Excecoes
{
    public class ExcecoesRegraNegocio : ApplicationException
    {
        public ExcecoesRegraNegocio(string message) : base(message) { }
    }
}
