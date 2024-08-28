using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayers.Entites.Entities;

namespace NLayers.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<DummyEntity> Entities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
    }
}
