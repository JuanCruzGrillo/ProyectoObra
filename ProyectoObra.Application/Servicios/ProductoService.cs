using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class ProductoService
    {
        private readonly AppDbContext _db;

        public ProductoService(AppDbContext db)
        {
            _db = db;
        }

        public List<Producto> ObtenerProductos()
        {
            return _db.Productos.Include(c => c.Categoria).Include(c => c.Rubro).ToList();
        }


        public void CrearProducto(Producto producto)
        {
            _db.Productos.Add(producto);
            _db.SaveChanges();
        }

        public Producto TraerProducto(int id)
        {
            try
            {

                Producto producto;
                producto = _db.Productos.SingleOrDefault(s => s.Id == id);
                return producto;
            }
            catch //Exception ex)
            {
                return new Producto();
            }
        }
        public void ActualizarProducto(Producto producto)
        {
            _db.Productos.Update(producto);
            _db.SaveChanges();
        }
        //Procedimiento para mostrar vista de form Delete

        public void EliminarProducto(Producto producto)
        {
            _db.Productos.Remove(producto);
            _db.SaveChanges();
        }

        public decimal ObtenerPrecio(int id)
        {
            Producto producto;
            producto = _db.Productos.SingleOrDefault(s => s.Id == id);
            return producto.Precio;
        }
    }
}