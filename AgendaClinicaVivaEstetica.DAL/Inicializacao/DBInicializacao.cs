using AgendaClinicaVivaEstetica.DAL.Contextos;
using AgendaClinicaVivaEstetica.Dominio.Entidades;
using AgendaClinicaVivaEstetica.Dominio.Enumeradores;
using System;
using System.Linq;

namespace AgendaClinicaVivaEstetica.DAL.Inicializacao
{
    public static class DBInicializacao
    {
        public static void Inicializar(DbContexto dbContexto)
        {
            dbContexto.Database.EnsureCreated();

            InicializarDados(dbContexto);
        }

        private static void InicializarDados(DbContexto dbContexto)
        {
            if (dbContexto.Marcacoes.Any() || dbContexto.Clientes.Any())
                return;

            var marcacoes = new Marcacao[]
           {
               new Marcacao(DateTime.Now, new Cliente("Michael", "Jackson", "44.415.079-1", "(68) 98275-1375", new Endereco("Logradouro", "Número", "Complemento", "Cidade", "Estado", "CEP")), EnumTipoServico.Massagem1Hora),
               new Marcacao(DateTime.Now, new Cliente("Silvio", "Santos", "38.225.184-2", "(32) 99401-5342", new Endereco("Logradouro", "Número", "Complemento", "Cidade", "Estado", "CEP")), EnumTipoServico.Massagem30Minutos),
               new Marcacao(DateTime.Now, new Cliente("Carolina", "Dieckmann", "40.569.492-1", "(61) 98533-1477", new Endereco("Logradouro", "Número", "Complemento", "Cidade", "Estado", "CEP")), EnumTipoServico.Outros),
               new Marcacao(DateTime.Now, new Cliente("Neymar", "Junior", "47.929.051-9", "(37) 98895-9142", new Endereco("Logradouro", "Número", "Complemento", "Cidade", "Estado", "CEP")), EnumTipoServico.Massagem1Hora),
               new Marcacao(DateTime.Now,  new Cliente("Viviane", "Araújo", "34.780.414-7", "(88) 99184-0317", new Endereco("Logradouro", "Número", "Complemento", "Cidade", "Estado", "CEP")), EnumTipoServico.Massagem30Minutos)
           };

            try
            {
                dbContexto.Marcacoes.AddRange(marcacoes);
                dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
