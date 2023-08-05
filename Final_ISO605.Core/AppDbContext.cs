using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TipoEgreso> TiposEgresos { get; set; }
        public DbSet<TipoIngreso> TiposIngresos { get; set; }
        public DbSet<TipoPago> TiposPagos { get; set; }
        public DbSet<Egreso> Egresos { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
