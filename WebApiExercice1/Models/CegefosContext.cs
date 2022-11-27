using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public class CegefosContext : DbContext
    {
        public CegefosContext(DbContextOptions<CegefosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Machine>().HasOne(m => m.Salle);
            mb.Entity<Salle>().HasMany(s => s.Machines).WithOne(m => m.Salle).HasForeignKey(m => m.SalleId);
            mb.Entity<Formation>().HasOne(f => f.Cours).WithMany(c => c.Formations).HasForeignKey(f => f.CoursId);
            mb.Entity<Formation>().HasOne(f => f.Salle).WithMany(s => s.Formations).HasForeignKey(f => f.SalleId);

            mb.Seed();
        }

        public DbSet<Salle> Salles { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Formation> Formations { get; set; }
    }
}
