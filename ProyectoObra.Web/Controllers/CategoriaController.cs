using Microsoft.AspNetCore.Mvc;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;

namespace ProyectoObra.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        {
            var categorias = _categoriaService.ObtenerCategorias();
            return View(categorias);
        }
        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaService.CrearCategoria(categoria);

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
            Categoria? categoria = _categoriaService.TraerCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        //Procedimiento para actualizar el registro en la DB
        [HttpPost]
        public IActionResult Update(Categoria categoria)
        {
            if (ModelState.IsValid && categoria.Id > 0)
            {
                _categoriaService.ActualizarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        public IActionResult Delete(int id)
        {
            //Student? student = _db.Students.SingleOrDefault(s => s.Id == id);
            Categoria? categoria = _categoriaService.TraerCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(Categoria categoria)
        {
            if (ModelState.IsValid && categoria.Id > 0)
            {
                _categoriaService.EliminarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}
