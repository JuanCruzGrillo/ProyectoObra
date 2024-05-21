using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class ContratacionProductoService
    {
        private readonly AppDbContext _db;

        public ContratacionProductoService(AppDbContext db)
        {
            _db = db;
        }

        public List<ContratacionProducto> ObtenerContratacionProductos()
        {
            return _db.ContratacionProductos.Include(c => c.Producto).Include(c => c.Contratacion).ToList();
        }


        public void CrearContratacionProducto(ContratacionProducto contratacionproducto)
        {
            contratacionproducto.Activo = true;
            _db.ContratacionProductos.Add(contratacionproducto);
            _db.SaveChanges();
        }

        public List<ContratacionProducto> TraerContratacionProducto(int id)
        {
            try
            {

                ContratacionProducto contratacionproducto;
                return _db.ContratacionProductos.Include(cp => cp.Producto).ThenInclude(p => p.Categoria).Include(p => p.Producto.Rubro).Include(cp => cp.Contratacion).ThenInclude(c=> c.Empresa).Where(cp => cp.ContratacionId == id).ToList();
             
            }
            catch //Exception ex)
            {
                return new List<ContratacionProducto>();
            }
        }
        public void ActualizarContratacionProducto(ContratacionProducto contratacionproducto)
        {
            _db.ContratacionProductos.Update(contratacionproducto);
            _db.SaveChanges();
        }
        //Procedimiento para mostrar vista de form Delete

        public void EliminarContratacionProducto(ContratacionProducto contratacionproducto)
        {
            _db.ContratacionProductos.Remove(contratacionproducto);
            _db.SaveChanges();
        }

    }
}