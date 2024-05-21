using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoObra.Application.Servicios;
using ProyectoObra.Domain.Entities;
using ProyectoObra.Infrastructure.Context;
using ProyectoObra.Web.Models;
using System.Security.AccessControl;

namespace ProyectoObra.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly CategoriaService _categoriaService;
        private readonly RubroService _rubroService;


        public ProductoController(ProductoService productoService, CategoriaService categoriaService, RubroService rubroService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
            _rubroService = rubroService;
        }
        //Procedimiento para mostrar todos los registros en DT2
        public IActionResult Index()
        {
            var productos = _productoService.ObtenerProductos();
            return View(productos);
        }
        //Procedimiento para mostrar vista del form Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productoService.CrearProducto(CambiarModelaClase(model));
                return RedirectToAction("Index");

            }
            return View("Create");
        }
        public IActionResult Create()
        {
            ViewData["Categoria"] = new SelectList(_categoriaService.ObtenerCategorias(), "Id", "Descripcion");
            ViewData["Rubro"] = new SelectList(_rubroService.ObtenerRubros(), "Id", "Descripcion");

            return View();

        }

        //Procedimiento para guardar el registro en la DB


        //Procedimiento para mostrar la vista de form Edit
        public IActionResult Edit(int id)
        {
            Producto? producto = _productoService.TraerProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Categoria"] = new SelectList(_categoriaService.ObtenerCategorias(), "Id", "Descripcion");
            ViewData["Rubro"] = new SelectList(_rubroService.ObtenerRubros(), "Id", "Descripcion");

            return View(CambiarClaseaModel(producto));
        }
        //Procedimiento para actualizar el registro en la DB
        [HttpPost]
        public IActionResult Update(ProductoViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _productoService.ActualizarProducto(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        //Procedimiento para mostrar vista de form Delete

        public IActionResult Delete(int id)
        {
            //Student? student = _db.Students.SingleOrDefault(s => s.Id == id);
            Producto? producto = _productoService.TraerProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(CambiarClaseaModel(producto));
        }

        [HttpPost, ActionName("Destroy")]
        public IActionResult Destroy(ProductoViewModel model)
        {
            if (ModelState.IsValid && model.Id > 0)
            {
                _productoService.EliminarProducto(CambiarModelaClase(model));
                return RedirectToAction("Index");
            }
            return View("Delete");
        }


        public static Producto CambiarModelaClase(ProductoViewModel model)
        {
            var producto = new Producto()
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                CategoriaId = model.CategoriaId,
                RubroId= model.RubroId,
                Precio = model.Precio

            };
            return producto;
        }
        public static ProductoViewModel CambiarClaseaModel(Producto producto)
        {
            var model = new ProductoViewModel()
            {
                Id = producto.Id,
                Descripcion = producto.Descripcion,
                CategoriaId = (int)producto.CategoriaId,
                RubroId = (int)producto.RubroId,
                Precio = producto.Precio
            };
            return model;
        }
    }
}
