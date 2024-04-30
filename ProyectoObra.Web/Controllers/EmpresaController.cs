using Microsoft.AspNetCore.Mvc;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        {
            var empresas = _empresaService.ObtenerEmpresas();
            return View(empresas);
        }
        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        public IActionResult Crear(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _empresaService.CrearEmpresa(empresa);

                return RedirectToAction("Index");
            }
            return View("Create");
        }
        public IActionResult Create()
        {
            return View();
        }

        //Procedimiento para guardar el registro en la DB


        //Procedimiento para mostrar la vista de form Edit
        public IActionResult Edit(int id)
        {
            Empresa? empresa = _empresaService.TraerEmpresa(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }
        //Procedimiento para actualizar el registro en la DB
        [HttpPost]
        public IActionResult Update(Empresa empresa)
        {
            if (ModelState.IsValid && empresa.Id > 0)
            {
                _empresaService.ActualizarEmpresa(empresa);
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        public IActionResult Delete(int id)
        {
            //Student? student = _db.Students.SingleOrDefault(s => s.Id == id);
            Empresa? empresa = _empresaService.TraerEmpresa(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(Empresa empresa)
        {
            if (ModelState.IsValid && empresa.Id > 0)
            {
                _empresaService.EliminarEmpresa(empresa);
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}
