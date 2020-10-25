using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Intelutions.Data.Mapping.Confidencialidad;
using Intelutions.Entities.Confidencialidad;

namespace Intelutions.Data
{
    public class DbContextIntelutions : DbContext
    {
        public DbSet<Permiso> Permisos { get; set; }

        public DbContextIntelutions(DbContextOptions<DbContextIntelutions> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PermisoMap());
        }
    }
}
