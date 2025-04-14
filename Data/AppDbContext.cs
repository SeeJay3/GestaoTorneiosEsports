using GestaoTorneiosEsports.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoTorneiosEsports.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        ////protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configuração do relacionamento entre Torneio e Equipe
        //    modelBuilder.Entity<Equipe>()
        //        .HasOne(e => e.Torneio)
        //        .WithMany(t => t.Equipes)
        //        .HasForeignKey(e => e.TorneioId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}