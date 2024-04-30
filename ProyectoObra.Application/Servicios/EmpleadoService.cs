using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class EmpleadoService
    {
        private readonly AppDbContext _db;

        public EmpleadoService(AppDbContext db)
        {
            _db = db;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _db.Empleados.Include(c => c.Empresa).ToList();
        }


        public void CrearEmpleado(Empleado empleado)
        {
            _db.Empleados.Add(empleado);
            _db.SaveChanges();
        }

        public Empleado TraerEmpleado(int id)
        {
            try
            {

                Empleado empleado;
                empleado = _db.Empleados.SingleOrDefault(s => s.Id == id);
                return empleado;
            }
            catch //Exception ex)
            {
                return new Empleado();
            }
        }
        public void ActualizarEmpleado(Empleado empleado)
        {
            _db.Empleados.Update(empleado);
            _db.SaveChanges();
        }
        //Procedimiento para mostrar vista de form Delete

        public void EliminarEmpleado(Empleado empleado)
        {
            _db.Empleados.Remove(empleado);
            _db.SaveChanges();
        }

    }
}