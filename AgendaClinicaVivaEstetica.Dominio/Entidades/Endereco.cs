using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaClinicaVivaEstetica.Dominio.Entidades
{
    public class Endereco
    {
        private Endereco() { }

        public Endereco(string logradouro, string numero, string complemento, string cidade, string estado, string cEP)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
        }

        [Key]
        public Guid IdEndereco { get; private set; }

        public string Logradouro { get; private set; }

        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string CEP { get; private set; }

        public Guid IdCliente { get; private set; }

        public Cliente Cliente { get; private set; }
    }
}
