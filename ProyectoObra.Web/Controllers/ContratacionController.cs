using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;
using ProyectoObra.Web.Models;
using System.Security.AccessControl;

namespace ProyectoObra.Web.Controllers
{
    public class ContratacionController : Controller
    {
        private readonly ContratacionService _contratacionService;
        private readonly EmpresaService _empresaService;


        public ContratacionController(ContratacionService contratacionService, EmpresaService empresaService)
        {
            _contratacionService = contratacionService;
            _empresaService = empresaService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        {
            var contratacions = _contratacionService.ObtenerContrataciones();
            return View(contratacions);
        }
        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(ContratacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contratacionService.CrearContratacion(CambiarModelaClase(model));
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
            Contratacion? contratacion = _contratacionService.TraerContratacion(id);
            if (contratacion == null)
            {
                return NotFound();
            }
            ViewData["Empresa"] = new SelectList(_empresaService.ObtenerEmpresas(), "Id", "Descripcion");
            return View(CambiarClaseaModel(contratacion));
        }
        //Procedimiento para actualizar el registro en la DB
        [HttpPost]
        public IActionResult Update(ContratacionViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _contratacionService.ActualizarContratacion(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        public IActionResult Delete(int id)
        {
            //Student? student = _db.Students.SingleOrDefault(s => s.Id == id);
            Contratacion? contratacion = _contratacionService.TraerContratacion(id);
            if (contratacion == null)
            {
                return NotFound();
            }


            ViewData["Empresa"] = new SelectList(_empresaService.ObtenerEmpresas(), "Id", "Descripcion");
          return View(CambiarClaseaModel(contratacion));
        }

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(ContratacionViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _contratacionService.EliminarContratacion(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

        public IActionResult Finalizar(int id)
        {
            if (id > 0)
            {
                _contratacionService.FinalizarContratacion(id);
                return RedirectToAction("Index");
            }
            return View();
        }
        


        public static Contratacion CambiarModelaClase(ContratacionViewModel model)
        {
            var contratacion = new Contratacion()
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                FechaInicio = model.FechaInicio,
                idEmpresa = model.EmpresaId
            };
            return contratacion;
        }
        public static ContratacionViewModel CambiarClaseaModel(Contratacion contratacion)
        {
            var model = new ContratacionViewModel()
            {
                Id = contratacion.Id,
                Descripcion = contratacion.Descripcion,
                EmpresaId = (int)contratacion.idEmpresa,
                FechaInicio = contratacion.FechaInicio
            };
            return model;
        }
    }
}
