﻿using AgendaClinicaVivaEstetica.Dominio.Enumeradores;
using AgendaClinicaVivaEstetica.Dominio.Excecoes;
using AgendaClinicaVivaEstetica.Dominio.Mensagens;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaClinicaVivaEstetica.Dominio.Entidades
{
    public class Marcacao
    {
        public Marcacao() { }

        public Marcacao(DateTime dataMarcacao, Cliente cliente, EnumTipoServico enumTipoServico)
        {
            DataMarcacao = dataMarcacao;
            Cliente = new Cliente(cliente.Nome, cliente.Sobrenome, cliente.Documento, cliente.Celular, cliente.Endereco);
            EnumTipoServico = enumTipoServico;
        }

        [Key]
        public Guid IdMarcacao { get; set; }

        public DateTime DataMarcacao { get; set; }

        public EnumTipoServico EnumTipoServico { get; set; }

        public Guid IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public void Validacao(EnumTipoSolicitacao enumTipoSolicitacao)
        {
            //Validação para horário entre as 8hs e as 16hs.
            var horaDaMarcacao = DataMarcacao.Hour;

            if (enumTipoSolicitacao != EnumTipoSolicitacao.Exclusao && (horaDaMarcacao >= 16 || horaDaMarcacao < 8))
            {
                throw new ExcecoesRegraNegocio(MensagensGerais.MSG0002);
            }

            //TODO validar regras para perfeito funcionamento, rever e testar mensagens na camada de apresentaçao na tela de cancelamento.
            //Validação horário alteração/cancelamento
            //if (enumTipoSolicitacao != EnumTipoSolicitacao.Inclusao)
            //{
            //    if (DataMarcacao.AddDays(1) >= DateTime.Now)
            //        throw new ExcecoesRegraNegocio(MensagensGerais.MSG0006);

            //    if (EnumTipoServico != EnumTipoServico.Outros && DataMarcacao.AddHours(24) >= DateTime.Now)
            //        throw new ExcecoesRegraNegocio(MensagensGerais.MSG0007);
            //}
        }
    }
}
