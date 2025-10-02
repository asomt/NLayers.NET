using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayers.Entites.Entities;

namespace NLayers.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Automovil> Automoviles { get; set; }

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
