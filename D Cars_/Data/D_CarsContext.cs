using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using D_Cars_.Models;

namespace D_Cars_.CONTEXT
{
    public class D_CarsContext : DbContext
    {
        public D_CarsContext (DbContextOptions<D_CarsContext> options)
            : base(options)
        {
        }

        public DbSet<D_Cars_.Models.Productos> Productos { get; set; }

        public DbSet<D_Cars_.Models.Servicies> Servicies { get; set; }

        public DbSet<D_Cars_.Models.Sucursales> Sucursales { get; set; }

        public DbSet<D_Cars_.Models.Marcas> Marcas { get; set; }

        public DbSet<D_Cars_.Models.Descuentos> Descuentos { get; set; }
    }
}
