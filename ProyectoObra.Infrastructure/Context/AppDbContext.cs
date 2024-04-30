using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Infrastructure.Context
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<Empresa> Empresas { get; set; }       
        public DbSet<Contratacion> Contrataciones { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<ContratacionProducto> ContratacionProductos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
