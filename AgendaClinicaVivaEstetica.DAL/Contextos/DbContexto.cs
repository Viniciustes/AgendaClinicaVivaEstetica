using AgendaClinicaVivaEstetica.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendaClinicaVivaEstetica.DAL.Contextos
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Marcacao> Marcacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(a => a.Endereco).WithOne(b => b.Cliente)
                .HasForeignKey<Endereco>(e => e.IdCliente);
        }

    }
}
