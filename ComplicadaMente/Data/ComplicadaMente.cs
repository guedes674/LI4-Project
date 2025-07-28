using Microsoft.EntityFrameworkCore;
using ComplicadaMente.Models;

namespace ComplicadaMente.Data
{
    public class ComplicadaMenteContext : DbContext
    {
        public ComplicadaMenteContext(DbContextOptions<ComplicadaMenteContext> options)
            : base(options) { }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<QuebraCabeca> QuebraCabecas { get; set; }
        public DbSet<QuebraCabecaEncomenda> QuebraCabecaEncomendas { get; set; }
        public DbSet<PecaEncomenda> PecaEncomendas { get; set; }
        public DbSet<ManualStep> ManualSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuebraCabecaEncomenda>()
                .HasKey(q => new { q.EncomendaId, q.QuebraCabecaId });
            modelBuilder.Entity<PecaEncomenda>()
                .HasKey(p => new { p.EncomendaId, p.PecaId });

            modelBuilder.Entity<PecaEncomenda>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(9,2)");

            modelBuilder.Entity<QuebraCabecaEncomenda>()
                .Property(q => q.Preco)
                .HasColumnType("decimal(9,2)");
        }
    }
}