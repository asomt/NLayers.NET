using Microsoft.EntityFrameworkCore;
using NLayers.API.Models1;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NLayers.API.Data1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Automovil> Automoviles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automovil>()
                .HasIndex(a => a.NumeroMotor)
                .IsUnique();

            modelBuilder.Entity<Automovil>()
                .HasIndex(a => a.NumeroChasis)
                .IsUnique();
        }
    }

}
