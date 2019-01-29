using AgendaClinicaVivaEstetica.Dominio.Excecoes;
using AgendaClinicaVivaEstetica.Dominio.Mensagens;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaClinicaVivaEstetica.Dominio.Entidades
{
    public class Cliente
    {
        private Cliente() { }

        public Cliente(string nome, string sobrenome, string documento, string celular, Endereco endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Celular = celular;
            Endereco = new Endereco(endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Cidade, endereco.Estado, endereco.CEP);
        }

        [Key]
        public Guid IdCliente { get; private set; }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Documento { get; private set; }

        public string Celular { get; private set; }

        public Endereco Endereco { get; private set; }

        public void Validacao()
        {
            //Validar Nome
            if(string.IsNullOrWhiteSpace(Nome))
                 throw new ExcecoesRegraNegocio(MensagensGerais.MSG0003);

            //Validar Documento
            if (string.IsNullOrWhiteSpace(Documento))
                throw new ExcecoesRegraNegocio(MensagensGerais.MSG0004);

            //Validar Celular
            if (string.IsNullOrWhiteSpace(Celular))
                throw new ExcecoesRegraNegocio(MensagensGerais.MSG0005);
        }
    }
}
