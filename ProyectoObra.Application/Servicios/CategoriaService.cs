using System.Collections.Generic;
using System.Linq;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class CategoriaService
    {
        private readonly AppDbContext _db;

        public CategoriaService(AppDbContext db)
        {
            _db = db;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _db.Categorias.ToList();
        }


        public void CrearCategoria(Categoria categoria)
        { 
             _db.Categorias.Add(categoria);
             _db.SaveChanges();
        }

        public Categoria TraerCategoria(int id)
        {
            try
            {

                Categoria categoria;
                categoria = _db.Categorias.SingleOrDefault(s => s.Id == id);
                return categoria;
            }
            catch //Exception ex)
            {
                return new Categoria();
            }            
        }
        public void ActualizarCategoria(Categoria categoria)
        { 
                _db.Categorias.Update(categoria);
                _db.SaveChanges();
        }
        //Procedimiento para mostrar vista de form Delete

        public void EliminarCategoria(Categoria categoria)
        {
                _db.Categorias.Remove(categoria);
                _db.SaveChanges();
        }

    }
}