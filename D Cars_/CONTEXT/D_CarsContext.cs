using System;
using Microsoft.EntityFrameworkCore;

using D_Cars_.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D_Cars_.Context
{
    public class D_Cars_Context: DbContext
    {
        public D_Cars_Context(DbContextOptions<D_Cars_Context> options) : base(options)
        {

        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Servicies> Servicies { get; set; }
        public DbSet<Sucursales> Surcursales { get; set; }
        public DbSet<Descuentos> Descuentos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }

    }
}
