using System.Collections.Generic;
using System.Linq;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Application.Servicios
{
    public class EmpresaService
    {
        private readonly AppDbContext _db;

        public EmpresaService(AppDbContext db)
        {
            _db = db;
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return _db.Empresas.ToList();
        }


        public void CrearEmpresa(Empresa empresa)
        { 
             _db.Empresas.Add(empresa);
             _db.SaveChanges();
        }

        public Empresa TraerEmpresa(int id)
        {
            try
            {
                Empresa empresa;
                empresa = _db.Empresas.SingleOrDefault(s => s.Id == id);
                return empresa;
            }
            catch //Exception ex)
            {
                return new Empresa();
            }            
        }
        public void ActualizarEmpresa(Empresa empresa)
        { 
                _db.Empresas.Update(empresa);
                _db.SaveChanges();
        }
        //Procedimiento para mostrar vista de form Delete

        public void EliminarEmpresa(Empresa empresa)
        {
                _db.Empresas.Remove(empresa);
                _db.SaveChanges();
        }

    }
}