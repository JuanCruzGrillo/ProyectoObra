using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;
using ProyectoObra.Web.Models;
using System.Security.AccessControl;

namespace ProyectoObra.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoService _empleadoService;
        private readonly EmpresaService _empresaService;


        public EmpleadoController(EmpleadoService empleadoService, EmpresaService empresaService)
        {
            _empleadoService = empleadoService;
            _empresaService = empresaService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        {
            var empleados = _empleadoService.ObtenerEmpleados();
            return View(empleados);
        }
        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(EmpleadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _empleadoService.CrearEmpleado(CambiarModelaClase(model));
                return RedirectToAction("Index");

            }
            return View("Create");
        }
        public IActionResult Create()
        {
            ViewData["Empresa"] = new SelectList(_empresaService.ObtenerEmpresas(), "Id", "Descripcion");
            return View();
        }

        //Procedimiento para guardar el registro en la DB


        //Procedimiento para mostrar la vista de form Edit
        public IActionResult Edit(int id)
        {
            Empleado? empleado = _empleadoService.TraerEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["Empresa"] = new SelectList(_empresaService.ObtenerEmpresas(), "Id", "Descripcion");
            return View(CambiarClaseaModel(empleado));
        }
        //Procedimiento para actualizar el registro en la DB
        [HttpPost]
        public IActionResult Update(EmpleadoViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _empleadoService.ActualizarEmpleado(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        public IActionResult Delete(int id)
        {
            //Student? student = _db.Students.SingleOrDefault(s => s.Id == id);
            Empleado? empleado = _empleadoService.TraerEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(CambiarClaseaModel(empleado));
        }

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(EmpleadoViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _empleadoService.EliminarEmpleado(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Delete");
        }


        public static Empleado CambiarModelaClase(EmpleadoViewModel model)
        {
            var empleado = new Empleado()
            {
                Id = model.Id,
                FullName = model.FullName,
                Age = model.Age,
                EmpresaId = model.EmpresaId
            };
            return empleado;
        }
        public static EmpleadoViewModel CambiarClaseaModel(Empleado empleado)
        {
            var model = new EmpleadoViewModel()
            {
                Id = empleado.Id,
                FullName = empleado.FullName,
                Age = empleado.Age,
                EmpresaId = empleado.EmpresaId,
            };
            return model;
        }
    }
}
