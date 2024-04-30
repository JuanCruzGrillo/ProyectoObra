using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;
using ProyectoObra.Web.Models;
using System.Security.AccessControl;

namespace ProyectoObra.Web.Controllers
{
    public class RubroController : Controller
    {
        private readonly RubroService _rubroService;
        private readonly EmpresaService _empresaService;


        public RubroController(RubroService rubroService, EmpresaService empresaService)
        {
            _rubroService = rubroService;
            _empresaService = empresaService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        {
            var rubros = _rubroService.ObtenerRubros();
            return View(rubros);
        }
        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(RubroViewModel model)
        {
            if (ModelState.IsValid)
            {
                _rubroService.CrearRubro(CambiarModelaClase(model));
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
            Rubro? rubro = _rubroService.TraerRubro(id);
            if (rubro == null)
            {
                return NotFound();
            }
            ViewData["Empresa"] = new SelectList(_empresaService.ObtenerEmpresas(), "Id", "Descripcion");
            return View(CambiarClaseaModel(rubro));
        }
        //Procedimiento para actualizar el registro en la DB
        [HttpPost]
        public IActionResult Update(RubroViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _rubroService.ActualizarRubro(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        public IActionResult Delete(int id)
        {
            //Student? student = _db.Students.SingleOrDefault(s => s.Id == id);
            Rubro? rubro = _rubroService.TraerRubro(id);
            if (rubro == null)
            {
                return NotFound();
            }
            return View(CambiarClaseaModel(rubro));
        }

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(RubroViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _rubroService.EliminarRubro(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Delete");
        }


        public static Rubro CambiarModelaClase(RubroViewModel model)
        {
            var rubro = new Rubro()
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                EmpresaId = model.EmpresaId
            };
            return rubro;
        }
        public static RubroViewModel CambiarClaseaModel(Rubro rubro)
        {
            var model = new RubroViewModel()
            {
                Id = rubro.Id,
                Descripcion = rubro.Descripcion,
                EmpresaId = rubro.EmpresaId,
            };
            return model;
        }
    }
}
