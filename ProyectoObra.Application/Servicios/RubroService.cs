using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class RubroService
    {
        private readonly AppDbContext _db;

        public RubroService(AppDbContext db)
        {
            _db = db;
        }

        public List<Rubro> ObtenerRubros()
        {
            return _db.Rubros.Include(c => c.Empresa).ToList();
        }


        public void CrearRubro(Rubro rubro)
        {
            _db.Rubros.Add(rubro);
            _db.SaveChanges();
        }

        public Rubro TraerRubro(int id)
        {
            try
            {

                Rubro rubro;
                rubro = _db.Rubros.SingleOrDefault(s => s.Id == id);
                return rubro;
            }
            catch //Exception ex)
            {
                return new Rubro();
            }
        }
        public void ActualizarRubro(Rubro rubro)
        {
            _db.Rubros.Update(rubro);
            _db.SaveChanges();
        }
        //Procedimiento para mostrar vista de form Delete

        public void EliminarRubro(Rubro rubro)
        {
            _db.Rubros.Remove(rubro);
            _db.SaveChanges();
        }

    }
}