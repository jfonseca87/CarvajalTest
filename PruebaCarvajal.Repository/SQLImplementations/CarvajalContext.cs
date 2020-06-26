using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PruebaCarvajal.Domain;

namespace PruebaCarvajal.Repository.SQLImplementations
{
    public class CarvajalContext : DbContext
    {
        public CarvajalContext(DbContextOptions<CarvajalContext> options) 
            : base(options)
        {
        }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
