using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class ContratacionService
    {
        private readonly AppDbContext _db;

        public ContratacionService(AppDbContext db)
        {
            _db = db;
        }

        public List<Contratacion> ObtenerContrataciones()
        {
            return _db.Contrataciones.Include(c => c.Empresa).ToList();
        }
        public List<Contratacion> ObtenerContratacionesActivas()
        {
            return _db.Contrataciones.Include(c => c.Empresa).Where(c => c.Activo == true ).Where(c => c.Finalizado == false).ToList();
        }
        public List<Contratacion> ObtenerContratacionesFinalizadas()
        {
            return _db.Contrataciones.Include(c => c.Empresa).Where(c => c.Activo == true).Where(c => c.Finalizado == true).ToList();
        }

        public void CrearContratacion(Contratacion contratacion)
        {
            contratacion.Activo = true;
            _db.Contrataciones.Add(contratacion);
            _db.SaveChanges();
        }
        public Contratacion TraerContratacion(int id)
        {
            try
            {

                Contratacion contratacion;
                contratacion = _db.Contrataciones.Include(c => c.Empresa).SingleOrDefault(s => s.Id == id);
                return contratacion;
            }
            catch //Exception ex)
            {
                return new Contratacion();
            }
        }
        public void ActualizarContratacion(Contratacion contratacion)
        {
            _db.Contrataciones.Update(contratacion);
            _db.SaveChanges();
        }

        public void FinalizarContratacion(int id)
        {
            Contratacion contratacion = TraerContratacion(id);
            contratacion.Finalizado = true;
            _db.Contrataciones.Update(contratacion);
            _db.SaveChanges();
        }

        //Procedimiento para mostrar vista de form Delete

        public void EliminarContratacion(Contratacion contratacion)
        {
            _db.Contrataciones.Remove(contratacion);
            _db.SaveChanges();
        }

    }
}