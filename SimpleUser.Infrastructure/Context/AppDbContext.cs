using Microsoft.EntityFrameworkCore;
using SimpleUser.Domain.Entities;

namespace SimpleUser.Infrastructure
{
    public class AppDbContext : DbContext
    {
        // O construtor recebe as opções de configuração do DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet para a entidade Usuario
        public DbSet<Usuario> Usuarios { get; set; }

        // Aqui você pode adicionar outros DbSets para outras entidades
        // public DbSet<OutraEntidade> OutraEntidades { get; set; }

        // Você pode configurar o modelo das entidades aqui, se necessário
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais podem ser feitas aqui, como chaves compostas, tabelas, etc.
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            // Exemplo de configuração de uma propriedade como chave primária:
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
        }
    }
}
